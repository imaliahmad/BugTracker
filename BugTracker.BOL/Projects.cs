using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
    [Table("Projects")]
    public class Projects : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        [Required(ErrorMessage = "Project Name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the organization ID (foreign key).
        /// </summary>
        public Guid OrgId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the project.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the project.
        /// </summary>
        public DateTime EndDate { get; set; }

        // Navigations

        /// <summary>
        /// Gets or sets the organization associated with the project.
        /// </summary>
        [ForeignKey("OrgId")]
        public virtual Organizations? Organizations { get; set; }

        /// <summary>
        /// Gets or sets the collection of project users associated with the project.
        /// </summary>
        public virtual IEnumerable<ProjectUser> ProjectUser { get; set; }

        /// <summary>
        /// Initializes a new instance of the Projects class.
        /// </summary>
        public Projects():base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the Projects class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the project.</param>
        /// <param name="orgId">The organization ID.</param>
        /// <param name="startDate">The start date of the project.</param>
        /// <param name="endDate">The end date of the project.</param>
        public Projects(string name, Guid orgId, DateTime startDate, DateTime endDate)
        {
            Name = name;
            OrgId = orgId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
