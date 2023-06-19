using BugTracker.BOL;

namespace BugTracker.Web.ViewModels
{
    public class OrganizationsVM:BaseEntityVM
    {
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
    }
}
