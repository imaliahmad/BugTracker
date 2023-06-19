using BugTracker.BOL;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Web.ViewModels
{
    public class ProjectsVM:BaseEntityVM
    {
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
        
        public virtual OrganizationsVM? Organizations { get; set; }

        /// <summary>
        /// Gets or sets the collection of project users associated with the project.
        /// </summary>
        //public virtual IEnumerable<ProjectUserVM> ProjectUser { get; set; }

    }
}
