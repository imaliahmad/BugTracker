using BugTracker.BOL.DataTypes;
using BugTracker.BOL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.API.DTOs.Request
{
    /// <summary>
    /// Represents the DTO for TaskHistory.
    /// </summary>
    public class TaskHistoryDTO:BaseEntityDTO
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
        [Required(ErrorMessage = "Status is required")]
        public StatusTypes? Status { get; set; }

        // Navigations

        /// <summary>
        /// Gets or sets the task associated with the task history.
        /// </summary>
        [ForeignKey("TaskId")]
        public virtual Tasks? Tasks { get; set; }

        /// <summary>
        /// Gets or sets the assignee associated with the task history.
        /// </summary>
        [ForeignKey("AssigneeId")]
        public virtual ProjectUser? ProjectUser { get; set; }

        /// <summary>
        /// Converts an TaskHistoryDTO object to an TaskHistory model.
        /// </summary>
        /// <param name="taskHistoryDTO">The TaskHistoryDTO object to convert.</param>
        /// <returns>The converted TaskHistory model.</returns>
        public static TaskHistory ToTaskHistoryModel(TaskHistoryDTO taskHistoryDto)
        {
            var taskHistory = new TaskHistory();
            taskHistory.Id = taskHistoryDto.Id;
            taskHistory.TaskId = taskHistoryDto.TaskId;
            taskHistory.AssigneeId = taskHistoryDto.AssigneeId;
            taskHistory.ModifiedDate = taskHistoryDto.ModifiedDate;
            taskHistory.Status = taskHistoryDto.Status;

            taskHistory.Tasks = taskHistoryDto.Tasks;
            taskHistory.ProjectUser = taskHistoryDto.ProjectUser;


            return taskHistory;

        }


        /// <summary>
        /// Converts an TaskHistory model to an TaskHistoryDTO object.
        /// </summary>
        /// <param name="model">The taskhistory model to convert.</param>
        /// <returns>The converted TaskHistoryDTO object.</returns>
        public static TaskHistoryDTO ToTaskHistoryDTO(TaskHistory model)
        {
            var taskHistoryDTO = new TaskHistoryDTO();
            taskHistoryDTO.Id = model.Id;
            taskHistoryDTO.TaskId = model.TaskId;
            taskHistoryDTO.AssigneeId = model.AssigneeId;
            taskHistoryDTO.ModifiedDate = model.ModifiedDate;
            taskHistoryDTO.Status = model.Status;

            taskHistoryDTO.Tasks = model.Tasks;
            taskHistoryDTO.ProjectUser = model.ProjectUser;
          

            return taskHistoryDTO;
        }

    }
}
