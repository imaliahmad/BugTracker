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
        public string ProjectName { get; set; }
        public Guid OrgId { get; set; }// foreign key

        [Required(ErrorMessage = "Project Description is required")]
        public string Description { get; set; }

        //Navigations

        [ForeignKey("OrgId")]
        public virtual Organizations? Organizations { get; set; }
        public virtual IEnumerable<ProjectUser> ProjectUser { get; set; }
        public Projects()
        {

        }

        public Projects(string projectName, Guid orgId, string description)
        {
            ProjectName = projectName;
            OrgId = orgId;
            Description = description;
        }
    }
}
