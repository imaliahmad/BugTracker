using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
    [Table("Tasks")]
    public class Tasks : BaseEntity
    {
        [Required(ErrorMessage = "Task Name is required")]
        public string Name { get; set; }
        public Guid ProjectUserId { get; set; }//foreign key

        [Required(ErrorMessage = "Task Description is required")]
        public string Description { get; set; }

        //Navigations

        [ForeignKey("ProjectUserId")]
        public virtual ProjectUser? ProjectUser { get; set; }
        public virtual IEnumerable<TaskDetail> TaskDetail { get; set; }
        public Tasks()
        {

        }

        public Tasks(string name, Guid projectUserId, string description)
        {
            Name = name;
            ProjectUserId = projectUserId;
            Description = description;
        }
    }
}
