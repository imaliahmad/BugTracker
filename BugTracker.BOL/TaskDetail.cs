using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
    [Table("TaskDetail")]
    public class TaskDetail : BaseEntity
    {
        public Guid TaskId { get; set; }// foreign key
        public Guid ProjectUserId { get; set; }// foreign key

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        public string Priority { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        //Navigations

        [ForeignKey("TaskId")]
        public virtual Tasks? Tasks { get; set; }

        [ForeignKey("ProjectUserId")]
        public virtual ProjectUser? ProjectUser { get; set; }
        public TaskDetail()
        {

        }

        public TaskDetail(Guid taskId, Guid projectUserId, DateTime startDate,
                           DateTime endDate, string priority, string status)
        {
            TaskId = taskId;
            ProjectUserId = projectUserId;
            StartDate = startDate;
            EndDate = endDate;
            Priority = priority;
            Status = status;
        }
    }
}
