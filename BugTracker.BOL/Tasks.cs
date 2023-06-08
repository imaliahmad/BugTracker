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
        [Required(ErrorMessage = "Task Name is required")]
        public string Name { get; set; }
        public Guid ProjectId { get; set; }//foreign key
        public Guid CreatedUserId { get; set; }//foreign key

        [Required(ErrorMessage = "Task Description is required")]
        public string Description { get; set; }
        public PriorityTypes? Priority { get; set; }
        public TaskTypes? Type { get; set; }
        public string TaskNo { get; set; }

        //Navigations

        [ForeignKey("ProjectId")]
        public virtual Projects? Projects { get; set; }

        [ForeignKey("CreatedUserId")]
        public virtual ProjectUser? ProjectUser { get; set; }

        public virtual IEnumerable<TaskHistory> TaskHistory { get; set; }
        public virtual IEnumerable<TaskComments> TaskComments { get; set; }
        public virtual IEnumerable<TaskAttachments> TaskAttachments { get; set; }
        public Tasks()
        {

        }

        public Tasks(string name, Guid projectId, Guid createdUserId,
                     string description, PriorityTypes? priority,
                     TaskTypes? type, string taskNo
                    )
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
