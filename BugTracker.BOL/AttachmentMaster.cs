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
    public class AttachmentMaster:BaseEntity
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public ImageTypes? Type { get; set; }
        public string FilePath { get; set; }

        //=== Navigations ===//
        public virtual IEnumerable<TaskAttachments> TaskAttachments { get; set; }

        public AttachmentMaster()
        {

        }

        public AttachmentMaster(string name, int size, string extension,
                                 ImageTypes? type, string filePath
                               )
        {
            Name = name;
            Size = size;
            Extension = extension;
            Type = type;
            FilePath = filePath;
        }
    }
}
