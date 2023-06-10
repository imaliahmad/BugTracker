using BugTracker.BOL;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.API.DTOs.Request
{
    /// <summary>
    /// Represents the DTO for ProjectUsers.
    /// </summary>
    public class ProjectUsersDTO:BaseEntityDTO
    {
        /// <summary>
        /// Gets or sets the project ID (foreign key).
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public Guid UserId { get; set; }

        // Navigations

        /// <summary>
        /// Gets or sets the project associated with the project user.
        /// </summary>
        [ForeignKey("ProjectId")]
        public virtual Projects? Projects { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the project user.
        /// </summary>
        [ForeignKey("UserId")]
        public virtual AppUsers? OrganizationUsers { get; set; }

        /// <summary>
        /// Gets or sets the collection of tasks associated with the project user.
        /// </summary>
        public virtual IEnumerable<Tasks>? Tasks { get; set; }

        /// <summary>
        /// Gets or sets the collection of task history associated with the project user.
        /// </summary>
        public virtual IEnumerable<TaskHistory>? TaskDetail { get; set; }

        /// <summary>
        /// Gets or sets the collection of task comments associated with the project user.
        /// </summary>
        public virtual IEnumerable<TaskComments>? TaskComments { get; set; }

        /// <summary>
        /// Converts an ProjectUsersDTO object to an ProjectUsers model.
        /// </summary>
        /// <param name="orgDTO">The ProjectUsersDTO object to convert.</param>
        /// <returns>The converted AppUsers model.</returns>
        public static ProjectUser ToProjectUsersModel(ProjectUsersDTO userDTO)
        {
            var user = new ProjectUser();
            user.Id = userDTO.Id;
            user.ProjectId = userDTO.ProjectId;
            user.UserId = userDTO.UserId;

            return user;
        }

        /// <summary>
        /// Converts an ProjectUsers model to an ProjectUsersDTO object.
        /// </summary>
        /// <param name="model">The ProjectUsers model to convert.</param>
        /// <returns>The converted ProjectUsersDTO object.</returns>
        public static ProjectUsersDTO ToProjectUsersDTO(ProjectUser model)
        {
            var userDTO = new ProjectUsersDTO();
            userDTO.Id = model.Id;
            userDTO.ProjectId = model.ProjectId;
            userDTO.UserId = model.UserId;

            return userDTO;
        }
    }
}

