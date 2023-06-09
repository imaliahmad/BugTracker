using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
    [Table("TaskAttachments")]
    public class TaskAttachments : BaseEntity
    {
        /// <summary>
        /// Gets or sets the task ID (foreign key).
        /// </summary>
        public Guid TaskId { get; set; }

        /// <summary>
        /// Gets or sets the attachment ID (foreign key).
        /// </summary>
        public Guid AttachmentId { get; set; }

        // Navigations

        /// <summary>
        /// Gets or sets the task associated with the task attachment.
        /// </summary>
        [ForeignKey("TaskId")]
        public virtual Tasks? Tasks { get; set; }

        /// <summary>
        /// Gets or sets the attachment associated with the task attachment.
        /// </summary>
        [ForeignKey("AttachmentId")]
        public virtual AttachmentMaster? AttachmentMaster { get; set; }

        /// <summary>
        /// Initializes a new instance of the TaskAttachments class.
        /// </summary>
        public TaskAttachments()
        {

        }

        /// <summary>
        /// Initializes a new instance of the TaskAttachments class with the specified parameters.
        /// </summary>
        /// <param name="taskId">The task ID.</param>
        /// <param name="attachmentId">The attachment ID.</param>
        public TaskAttachments(Guid taskId, Guid attachmentId)
        {
            TaskId = taskId;
            AttachmentId = attachmentId;
        }
    }
}
