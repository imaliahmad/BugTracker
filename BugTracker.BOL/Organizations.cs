using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
    [Table("Organizations")]
    public class Organizations:BaseEntity
    { 

        [Required(ErrorMessage = "Organization Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Organization Description is required")]
        public string Description { get; set; }

        //Navigate
        public virtual IEnumerable<OrganizationUsers> OrganizationUsers { get; set; }
        
        public Organizations()
        {

        }

        public Organizations(string name, string description):base(Guid.NewGuid())
        {
            Name = name;
            Description = description;
            OrganizationUsers = null;

        }
    }
}
