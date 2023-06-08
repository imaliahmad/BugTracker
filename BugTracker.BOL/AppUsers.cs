using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
    [Table("OrganizationUsers")]
    public class AppUsers:BaseEntity
    {
        public string Name { get; set; }
        public Guid OrgId { get; set; } //foreign key

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        /* Navigations */

        [ForeignKey("OrgId")]
        public virtual Organizations? Organizations { get; set; }

        
        public virtual IEnumerable<ProjectUser> ProjectUser { get; set; }
        public AppUsers()
        {

        }

        public AppUsers(string name, Guid orgId, string email, string password)
        {
            Name = name;
            OrgId = orgId;
            Email = email;
            Password = password;
        }
    }
}
