using BugTracker.BOL.DataTypes;
using BugTracker.Web.DataTypes;
using BugTracker.BOL;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Web.ViewModels
{
    public class TaskHistoryVM:BaseEntityVM
    {
        /// <summary>
        /// Gets or sets the task ID (foreign key).
        /// </summary>
        public Guid TaskId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the assignee (foreign key).
        /// </summary>
        public Guid AssigneeId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the task was modified.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the task.
        /// </summary>
        public StatusType? Status { get; set; }

        // Navigations

        /// <summary>
        /// Gets or sets the task associated with the task history.
        /// </summary>
        public virtual Tasks? Tasks { get; set; }

        /// <summary>
        /// Gets or sets the assignee associated with the task history.
        /// </summary>
        public virtual ProjectUser? ProjectUser { get; set; }

        public static TaskHistoryVM ToTaskHistoryVM(TaskHistory task)
        {
            TaskHistoryVM tasksVM = new TaskHistoryVM();
            Tasks tasks = new Tasks();
            ProjectUser projectUser = new ProjectUser();

            tasksVM.Id = task.Id;
            tasksVM.TaskId = task.TaskId;
            tasksVM.AssigneeId = task.AssigneeId;
            tasksVM.ModifiedDate = task.ModifiedDate;
            tasksVM.Status = (StatusType?)task.Status;

            if (task.Tasks != null)
            {
                tasks.Id = task.Tasks.Id;
                tasks.Name = task.Tasks.Name;
                tasks.ProjectId = task.Tasks.ProjectId;
                tasks.CreatedUserId = task.Tasks.CreatedUserId;
                tasks.Description = task.Tasks.Description;
                tasks.Priority = task.Tasks.Priority;
                tasks.Type = task.Tasks.Type;
                tasks.TaskNo = task.Tasks.TaskNo;
                tasksVM.Tasks = tasks;
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
