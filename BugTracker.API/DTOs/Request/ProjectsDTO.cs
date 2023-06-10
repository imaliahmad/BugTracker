using BugTracker.BOL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.API.DTOs.Request
{
    /// <summary>
    /// Represents the DTO for Projects.
    /// </summary>
    public class ProjectsDTO:BaseEntityDTO
    {
        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        [Required(ErrorMessage = "Project Name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the organization ID (foreign key).
        /// </summary>
        public Guid OrgId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the project.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the project.
        /// </summary>
        public DateTime EndDate { get; set; }

        // Navigations

        /// <summary>
        /// Gets or sets the organization associated with the project.
        /// </summary>
        [ForeignKey("OrgId")]
        public virtual Organizations? Organizations { get; set; }

        /// <summary>
        /// Gets or sets the collection of project users associated with the project.
        /// </summary>
        public virtual IEnumerable<ProjectUser>? ProjectUser { get; set; }

        /// <summary>
        /// Converts an ProjectsDTO object to an Projects model.
        /// </summary>
        /// <param name="orgDTO">The ProjecstDTO object to convert.</param>
        /// <returns>The converted Projects model.</returns>
        public static Projects ToProjectsModel(ProjectsDTO projectsDTO)
        {
            var project = new Projects();
            project.Id = projectsDTO.Id;
            project.Name = projectsDTO.Name;
            project.OrgId = projectsDTO.OrgId;
            project.StartDate = projectsDTO.StartDate;
            project.EndDate = projectsDTO.EndDate;

            return project;
        }

        /// <summary>
        /// Converts an Projects model to an ProjectsDTO object.
        /// </summary>
        /// <param name="model">The Projecst model to convert.</param>
        /// <returns>The converted ProjectsDTO object.</returns>
        public static ProjectsDTO ToProjectsDTO(Projects model)
        {
            var projectDTO = new ProjectsDTO();
            projectDTO.Id = model.Id;
            projectDTO.Name = model.Name;
            projectDTO.OrgId = model.OrgId;
            projectDTO.StartDate = model.StartDate;
            projectDTO.EndDate = model.EndDate;

            return projectDTO;
        }
    }
}
