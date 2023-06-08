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
        public string Email { get; set; }
        public double ContactNo { get; set; }

        //Navigate
        public virtual IEnumerable<AppUsers> AppUsers { get; set; }
        
        public Organizations()
        {

        }

        public Organizations(string name, string email, double contactNo)
        {
            Name = name;
            Email = email;
            ContactNo = contactNo;
        }
    }
}
