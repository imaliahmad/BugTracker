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
        public Guid ProjectRolesId { get; set; }// foreign key
        public Guid UserId { get; set; }

        //Navigations
        [ForeignKey("ProjectId")]
        public virtual Projects? Projects { get; set; }

        [ForeignKey("ProjectRolesId")]
        public virtual ProjectRoles? ProjectRoles { get; set; }

        [ForeignKey("UserId")]
        public virtual OrganizationUsers? OrganizationUsers { get; set; }
        public virtual IEnumerable<Tasks> Tasks { get; set; }
        public virtual IEnumerable<TaskDetail> TaskDetail { get; set; }
        public ProjectUser()
        {

        }

        public ProjectUser(Guid projectId, Guid projectRolesId, Guid userId)
        {
            ProjectId = projectId;
            ProjectRolesId = projectRolesId;
            UserId = userId;
        }
    }
}


