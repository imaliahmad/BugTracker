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
    public class OrganizationUsers:BaseEntity
    {
        public string Name { get; set; }
        public Guid OrgId { get; set; } //foreign key
        public Guid OrgRolesId { get; set; }//foreign key

        [Required(ErrorMessage = "User Code is required")]
        public int Code { get; set; }

        [Required(ErrorMessage = "Phone No is required")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        /* Navigations */

        [ForeignKey("OrgId")]
        public virtual Organizations? Organizations { get; set; }

        [ForeignKey("OrgRolesId")]
        public virtual OrganizationRoles? OrganizationRoles { get; set; }
        public virtual IEnumerable<ProjectUser> ProjectUser { get; set; }
        public OrganizationUsers()
        {

        }

        public OrganizationUsers(string name, Guid orgId, Guid orgRolesId, int code, 
                                 string phoneNo, string email, string address)
        {
            Name = name;
            OrgId = orgId;
            OrgRolesId = orgRolesId;
            Code = code;
            PhoneNo = phoneNo;
            Email = email;
            Address = address;
        }
    }
}
