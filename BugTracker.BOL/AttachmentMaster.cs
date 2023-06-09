using BugTracker.BOL.DataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
    [Table("AttachmentMaster")]
    public class AttachmentMaster : BaseEntity
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
        public virtual IEnumerable<TaskAttachments> TaskAttachments { get; set; }

        /// <summary>
        /// Initializes a new instance of the AttachmentMaster class.
        /// </summary>
        public AttachmentMaster()
        {

        }

        /// <summary>
        /// Initializes a new instance of the AttachmentMaster class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the attachment.</param>
        /// <param name="size">The size of the attachment.</param>
        /// <param name="extension">The extension of the attachment.</param>
        /// <param name="type">The type of the attachment.</param>
        /// <param name="filePath">The file path of the attachment.</param>
        public AttachmentMaster(string name, int size, string extension, ImageTypes? type, string filePath)
        {
            Name = name;
            Size = size;
            Extension = extension;
            Type = type;
            FilePath = filePath;
        }
    }
}
