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
        public Guid TaskId { get; set; }// foreign key
        public Guid AssigneeId { get; set; }// foreign key
        public DateTime ModifiedDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public StatusTypes? Status { get; set; }

        //Navigations

        [ForeignKey("TaskId")]
        public virtual Tasks? Tasks { get; set; }

        [ForeignKey("AssigneeId")]
        public virtual ProjectUser? ProjectUser { get; set; }
        public TaskHistory()
        {

        }

        public TaskHistory(Guid taskId, Guid assigneeId,
                           DateTime modifiedDate,
                           StatusTypes? status
                          )
        {
            TaskId = taskId;
            AssigneeId = assigneeId;
            ModifiedDate = modifiedDate;
            Status = status;
        }
    }
}
