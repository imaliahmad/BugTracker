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
        [Required(ErrorMessage = "Project Name is required")]
        public string Name { get; set; }
        public Guid OrgId { get; set; }// foreign key
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Navigations

        [ForeignKey("OrgId")]
        public virtual Organizations? Organizations { get; set; }
        public virtual IEnumerable<ProjectUser> ProjectUser { get; set; }
        public Projects()
        {

        }

        public Projects(string name, Guid orgId, DateTime startDate, DateTime endDate)
        {
            Name = name;
            OrgId = orgId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
