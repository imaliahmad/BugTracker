using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
    [Table("ProjectRoles")]
    public class ProjectRoles : BaseEntity
    {
        [Required(ErrorMessage = "Role Name is required")]
        public string Name { get; set; }

        //Navigate
        public virtual IEnumerable<ProjectUser> ProjectUser { get; set; }
        public ProjectRoles()
        {

        }

        public ProjectRoles(string name)
        {
            Name = name;
        }
    }
}
