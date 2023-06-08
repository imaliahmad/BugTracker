using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{

    [Table("ProjectUser")]
    public class ProjectUser : BaseEntity
    {
        public Guid ProjectId { get; set; }// foreign key
        public Guid UserId { get; set; }

        //Navigations
        [ForeignKey("ProjectId")]
        public virtual Projects? Projects { get; set; }
        

        [ForeignKey("UserId")]
        public virtual AppUsers? OrganizationUsers { get; set; }
        public virtual IEnumerable<Tasks> Tasks { get; set; }
        public virtual IEnumerable<TaskHistory> TaskDetail { get; set; }
        public virtual IEnumerable<TaskComments> TaskComments { get; set; }
        public ProjectUser()
        {

        }

        public ProjectUser(Guid projectId, Guid userId)
        {
            ProjectId = projectId;
            UserId = userId;
        }
    }
}


