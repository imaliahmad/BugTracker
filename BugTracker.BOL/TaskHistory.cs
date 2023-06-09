using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.BOL.DataTypes;

namespace BugTracker.BOL
{
    [Table("TaskHistory")]
    public class TaskHistory : BaseEntity
    {
        /// <summary>
        /// Gets or sets the task ID (foreign key).
        /// </summary>
        public Guid TaskId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the assignee (foreign key).
        /// </summary>
        public Guid AssigneeId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the task was modified.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the task.
        /// </summary>
        [Required(ErrorMessage = "Status is required")]
        public StatusTypes? Status { get; set; }

        // Navigations

        /// <summary>
        /// Gets or sets the task associated with the task history.
        /// </summary>
        [ForeignKey("TaskId")]
        public virtual Tasks? Tasks { get; set; }

        /// <summary>
        /// Gets or sets the assignee associated with the task history.
        /// </summary>
        [ForeignKey("AssigneeId")]
        public virtual ProjectUser? ProjectUser { get; set; }

        /// <summary>
        /// Initializes a new instance of the TaskHistory class.
        /// </summary>
        public TaskHistory()
        {

        }

        /// <summary>
        /// Initializes a new instance of the TaskHistory class with the specified parameters.
        /// </summary>
        /// <param name="taskId">The task ID.</param>
        /// <param name="assigneeId">The ID of the assignee.</param>
        /// <param name="modifiedDate">The date and time when the task was modified.</param>
        /// <param name="status">The status of the task.</param>
        public TaskHistory(Guid taskId, Guid assigneeId, DateTime modifiedDate, StatusTypes? status)
        {
            TaskId = taskId;
            AssigneeId = assigneeId;
            ModifiedDate = modifiedDate;
            Status = status;
        }
    }
}
