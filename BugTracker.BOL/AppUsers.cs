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
    public class AppUsers : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the organization ID (foreign key).
        /// </summary>
        public Guid OrgId { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        /* Navigations */

        /// <summary>
        /// Gets or sets the organization associated with the user.
        /// </summary>
        [ForeignKey("OrgId")]
        public virtual Organizations? Organizations { get; set; }

        /// <summary>
        /// Gets or sets the collection of project users associated with the user.
        /// </summary>
        public virtual IEnumerable<ProjectUser>? ProjectUser { get; set; }

        /// <summary>
        /// Initializes a new instance of the AppUsers class.
        /// </summary>
        public AppUsers()
        {

        }

        /// <summary>
        /// Initializes a new instance of the AppUsers class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="orgId">The organization ID.</param>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">The password of the user.</param>
        public AppUsers(string name, Guid orgId, string email, string password)
        {
            Name = name;
            OrgId = orgId;
            Email = email;
            Password = password;
        }
    }
}
