using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
    [Table("TaskComments")]
    public class TaskComments : BaseEntity
    {
        /// <summary>
        /// Gets or sets the task ID (foreign key).
        /// </summary>
        public Guid TaskId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who created the comment (foreign key).
        /// </summary>
        public Guid CreatedUserId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the comment was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the description of the comment.
        /// </summary>
        public string Description { get; set; }

        // Navigations

        /// <summary>
        /// Gets or sets the task associated with the comment.
        /// </summary>
        [ForeignKey("TaskId")]
        public virtual Tasks? Tasks { get; set; }

        /// <summary>
        /// Gets or sets the user who created the comment.
        /// </summary>
        [ForeignKey("CreatedUserId")]
        public virtual ProjectUser? ProjectUser { get; set; }

        /// <summary>
        /// Initializes a new instance of the TaskComments class.
        /// </summary>
        public TaskComments()
        {

        }

        /// <summary>
        /// Initializes a new instance of the TaskComments class with the specified parameters.
        /// </summary>
        /// <param name="taskId">The task ID.</param>
        /// <param name="createdUserId">The ID of the user who created the comment.</param>
        /// <param name="createdDate">The date and time when the comment was created.</param>
        /// <param name="description">The description of the comment.</param>
        public TaskComments(Guid taskId, Guid createdUserId, DateTime createdDate, string description)
        {
            TaskId = taskId;
            CreatedUserId = createdUserId;
            CreatedDate = createdDate;
            Description = description;
        }
    }
}
