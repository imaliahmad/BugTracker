using BugTracker.BOL.DataTypes;
using BugTracker.BOL;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BugTracker.Web.DataTypes;

namespace BugTracker.Web.ViewModels
{
    public class TasksVM:BaseEntityVM
    {
        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the project ID (foreign key).
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who created the task (foreign key).
        /// </summary>
        public Guid CreatedUserId { get; set; }

        /// <summary>
        /// Gets or sets the description of the task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the priority of the task.
        /// </summary>
        public PriorityTypes? Priority { get; set; }

        /// <summary>
        /// Gets or sets the type of the task.
        /// </summary>
        public TaskTypes? Type { get; set; }

        /// <summary>
        /// Gets or sets the task number.
        /// </summary>
        public string TaskNo { get; set; }

        // Navigations

        /// <summary>
        /// Gets or sets the project associated with the task.
        /// </summary>
        public virtual Projects? Projects { get; set; }

        /// <summary>
        /// Gets or sets the user who created the task.
        /// </summary>
        public virtual ProjectUser? ProjectUser { get; set; }

        public static TasksVM ToTasksVM(Tasks task)
        {
            TasksVM tasksVM = new TasksVM();
            Projects projects = new Projects();
            ProjectUser projectUser  = new ProjectUser();

            tasksVM.Id = task.Id;
            tasksVM.Name = task.Name;
            tasksVM.ProjectId = task.ProjectId;
            tasksVM.CreatedUserId = task.CreatedUserId;
            tasksVM.Description = task.Description;
            tasksVM.Priority = task.Priority;
            tasksVM.Type = task.Type;
            tasksVM.TaskNo = task.TaskNo;

            if (task.Projects != null)
            {
                projects.Id = task.Projects.Id;
                projects.Name = task.Projects.Name;
                projects.OrgId = task.Projects.OrgId;
                projects.StartDate = task.Projects.StartDate;
                projects.EndDate = task.Projects.EndDate;
                tasksVM.Projects = projects;
            }

            if (task.ProjectUser != null)
            {
                projectUser.Id = task.ProjectUser.Id;
                projectUser.ProjectId = task.ProjectUser.ProjectId;
                projectUser.UserId = task.ProjectUser.UserId;
                tasksVM.ProjectUser = projectUser;
            }
            
            return tasksVM;
        }

    }
}
