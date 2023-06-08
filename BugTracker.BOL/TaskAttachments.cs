using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
    [Table("TaskAttachments")]
    public class TaskAttachments:BaseEntity
    { 

        public Guid TaskId { get; set; }//foreign key
        public Guid AttachmentId { get; set; }//foreign key

        //=== Navigations ===//

        [ForeignKey("TaskId")]
        public virtual Tasks? Tasks { get; set; }

        [ForeignKey("AttachmentId")]
        public virtual AttachmentMaster? AttachmentMaster { get; set; }
        

        public TaskAttachments()
        {

        }

        public TaskAttachments(Guid taskId, Guid attachmentId)
        {
            TaskId = taskId;
            AttachmentId = attachmentId;
        }
    }
}
