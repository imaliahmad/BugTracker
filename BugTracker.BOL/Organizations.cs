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
    public class Organizations : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the organization.
        /// </summary>
        [Required(ErrorMessage = "Organization Name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email of the organization.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the contact number of the organization.
        /// </summary>
        public double ContactNo { get; set; }

        // Navigate

        /// <summary>
        /// Gets or sets the collection of app users associated with the organization.
        /// </summary>
        public virtual IEnumerable<AppUsers>? AppUsers { get; set; }

        /// <summary>
        /// Initializes a new instance of the Organizations class.
        /// </summary>
        public Organizations()
        {

        }

        /// <summary>
        /// Initializes a new instance of the "Organizations class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the organization.</param>
        /// <param name="email">The email of the organization.</param>
        /// <param name="contactNo">The contact number of the organization.</param>
        public Organizations(string name, string email, double contactNo)
        {
            Name = name;
            Email = email;
            ContactNo = contactNo;
        }
    }
}
