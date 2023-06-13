using BugTracker.BOL.DataTypes;
using BugTracker.BOL;

namespace BugTracker.API.DTOs.Request
{
    /// <summary>
    /// Represents the DTO for AttachmentMaster.
    /// </summary>
    public class AttachmentMasterDTO:BaseEntityDTO
    {
        /// <summary>
        /// Gets or sets the name of the attachment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the size of the attachment.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the extension of the attachment.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Gets or sets the type of the attachment.
        /// </summary>
        public ImageTypes? Type { get; set; }

        /// <summary>
        /// Gets or sets the file path of the attachment.
        /// </summary>
        public string FilePath { get; set; }

        //=== Navigations ===//

        /// <summary>
        /// Gets or sets the collection of task attachments associated with the attachment.
        /// </summary>
        public virtual IEnumerable<TaskAttachments>? TaskAttachments { get; set; }

        /// <summary>
        /// Converts an AttachmentMasterDTO object to an AttachmentMaster model.
        /// </summary>
        /// <param name="taskDTO">The AttachmentMasterDTO object to convert.</param>
        /// <returns>The converted AttachmentMaster model.</returns>
        public static AttachmentMaster ToAttachmentMasterModel(AttachmentMasterDTO masterDto)
        {
            var master = new AttachmentMaster();
            master.Id = masterDto.Id;
            master.Name = masterDto.Name;
            master.Size = masterDto.Size;
            master.Extension = masterDto.Extension;
            master.Type = masterDto.Type;
            master.FilePath = masterDto.FilePath;

            return master;

        }


        /// <summary>
        /// Converts an AttachmentMaster model to an AttachmentMasterDTO object.
        /// </summary>
        /// <param name="model">The AttachmentMaster model to convert.</param>
        /// <returns>The converted AttachmentMasterDTO object.</returns>
        public static AttachmentMasterDTO ToAttachmentMasterDTO(AttachmentMaster model)
        {
            var masterDTO = new AttachmentMasterDTO();
            masterDTO.Id = model.Id;
            masterDTO.Name = model.Name;
            masterDTO.Size = model.Size;
            masterDTO.Extension = model.Extension;
            masterDTO.Type = model.Type;
            masterDTO.FilePath = model.FilePath;

            return masterDTO;
        }
    }
}
