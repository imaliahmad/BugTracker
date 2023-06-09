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
    [Table("Tasks")]
    public class Tasks : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        [Required(ErrorMessage = "Task Name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the project ID (foreign key).
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who created the task (foreign key).
        /// </summary>
        public Guid CreatedUserId { get; set; }

        /// <summary>
        /// Gets or sets the description of the task.
        /// </summary>
        [Required(ErrorMessage = "Task Description is required")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the priority of the task.
        /// </summary>
        public PriorityTypes? Priority { get; set; }

        /// <summary>
        /// Gets or sets the type of the task.
        /// </summary>
        public TaskTypes? Type { get; set; }

        /// <summary>
        /// Gets or sets the task number.
        /// </summary>
        public string TaskNo { get; set; }

        // Navigations

        /// <summary>
        /// Gets or sets the project associated with the task.
        /// </summary>
        [ForeignKey("ProjectId")]
        public virtual Projects? Projects { get; set; }

        /// <summary>
        /// Gets or sets the user who created the task.
        /// </summary>
        [ForeignKey("CreatedUserId")]
        public virtual ProjectUser? ProjectUser { get; set; }

        /// <summary>
        /// Gets or sets the task history associated with the task.
        /// </summary>
        public virtual IEnumerable<TaskHistory> TaskHistory { get; set; }

        /// <summary>
        /// Gets or sets the task comments associated with the task.
        /// </summary>
        public virtual IEnumerable<TaskComments> TaskComments { get; set; }

        /// <summary>
        /// Gets or sets the task attachments associated with the task.
        /// </summary>
        public virtual IEnumerable<TaskAttachments> TaskAttachments { get; set; }

        /// <summary>
        /// Initializes a new instance of the Tasks class.
        /// </summary>
        public Tasks()
        {

        }

        /// <summary>
        /// Initializes a new instance of the Tasks class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the task.</param>
        /// <param name="projectId">The project ID.</param>
        /// <param name="createdUserId">The ID of the user who created the task.</param>
        /// <param name="description">The description of the task.</param>
        /// <param name="priority">The priority of the task.</param>
        /// <param name="type">The type of the task.</param>
        /// <param name="taskNo">The task number.</param>
        public Tasks(string name, Guid projectId, Guid createdUserId, string description, PriorityTypes? priority, TaskTypes? type, string taskNo)
        {
            Name = name;
            ProjectId = projectId;
            CreatedUserId = createdUserId;
            Description = description;
            Priority = priority;
            Type = type;
            TaskNo = taskNo;
        }
    }
}
