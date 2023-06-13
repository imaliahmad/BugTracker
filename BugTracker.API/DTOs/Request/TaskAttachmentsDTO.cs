using BugTracker.BOL;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.API.DTOs.Request
{
    /// <summary>
    /// Represents the DTO for Task Attachments.
    /// </summary>
    public class TaskAttachmentsDTO:BaseEntityDTO
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
        /// Converts an TaskAttachmentsDTO object to an TaskAttachments model.
        /// </summary>
        /// <param name="taskattachmentDTO">The TaskAttachmentsDTO object to convert.</param>
        /// <returns>The converted TaskAttachments model.</returns>
        public static TaskAttachments ToTaskAttachmentsModel(TaskAttachmentsDTO attachmentDto)
        {
            var attachment = new TaskAttachments();
            attachment.Id = attachmentDto.Id;
            attachment.TaskId = attachmentDto.TaskId;
            attachment.AttachmentId = attachmentDto.AttachmentId;


            return attachment;

        }


        /// <summary>
        /// Converts an TaskAttachments model to an TaskAttachmentsDTO object.
        /// </summary>
        /// <param name="model">The TaskAttachments model to convert.</param>
        /// <returns>The converted TaskAttachmentsDTO object.</returns>
        public static TaskAttachmentsDTO ToTaskAttachmentsDTO(TaskAttachments model)
        {
            var attachmentDTO = new TaskAttachmentsDTO();
            attachmentDTO.Id = model.Id;
            attachmentDTO.TaskId = model.TaskId;
            attachmentDTO.AttachmentId = model.AttachmentId;

            return attachmentDTO;
        }
    }
}
