using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
    [Table("TaskComments")]
    public class TaskComments:BaseEntity
    {
        public Guid TaskId { get; set; }// foreign key
        public Guid CreatedUserId { get; set; }// foreign key
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }

        //=== Navigations ===//

        [ForeignKey("TaskId")]
        public virtual Tasks? Tasks { get; set; }

        [ForeignKey("CreatedUserId")]
        public virtual ProjectUser? ProjectUser { get; set; }

        public TaskComments()
        {

        }

        public TaskComments(Guid taskId, Guid createdUserId,
                            DateTime createdDate, string description)
        {
            TaskId = taskId;
            CreatedUserId = createdUserId;
            CreatedDate = createdDate;
            Description = description;
        }
    }
}
