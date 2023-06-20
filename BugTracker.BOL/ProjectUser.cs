using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
    [Table("ProjectUser")]
    public class ProjectUser : BaseEntity
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
        public virtual AppUsers? AppUsers { get; set; }

        /// <summary>
        /// Gets or sets the collection of tasks associated with the project user.
        /// </summary>
        public virtual IEnumerable<Tasks> Tasks { get; set; }

        /// <summary>
        /// Gets or sets the collection of task history associated with the project user.
        /// </summary>
        public virtual IEnumerable<TaskHistory> TaskDetail { get; set; }

        /// <summary>
        /// Gets or sets the collection of task comments associated with the project user.
        /// </summary>
        public virtual IEnumerable<TaskComments> TaskComments { get; set; }

        /// <summary>
        /// Initializes a new instance of the ProjectUser class.
        /// </summary>
        public ProjectUser()
        {

        }

        /// <summary>
        /// Initializes a new instance of the ProjectUser class with the specified parameters.
        /// </summary>
        /// <param name="projectId">The project ID.</param>
        /// <param name="userId">The user ID.</param>
        public ProjectUser(Guid projectId, Guid userId)
        {
            ProjectId = projectId;
            UserId = userId;
        }
    }
}
