using BugTracker.BOL;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Web.ViewModels
{
    public class ProjectUserVM:BaseEntityVM
    {
        /// <summary>
        /// Gets or sets the project ID (foreign key).
        /// </summary>
        public Guid? ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public Guid UserId { get; set; }

        // Navigations

        /// <summary>
        /// Gets or sets the project associated with the project user.
        /// </summary>
        public virtual Projects? Projects { get; set; }

        /// <summary>
        /// Gets or sets the users associated with the project user.
        /// </summary>
        public virtual AppUsers? AppUsers { get; set; }
    }
}
