using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
    [Table("OrganizationRoles")]
   public  class OrganizationRoles : BaseEntity
   {
     [Required(ErrorMessage = "Role Name is required")]
     public string Name { get; set; }

     //Navigate
     public virtual IEnumerable<OrganizationUsers> OrganizationUsers { get; set; }
        public OrganizationRoles()
        {

        }

        public OrganizationRoles(string name)
        {
            Name = name;
        }
    }
}
