using BugTracker.BOL.DataTypes;
using BugTracker.BOL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.API.DTOs.Request
{
    /// <summary>
    /// Represents the DTO for Tasks.
    /// </summary>
    public class TasksDTO:BaseEntityDTO
    {
        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        [Required(ErrorMessage = "Task Name is required")]
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
        [Required(ErrorMessage = "Task Description is required")]
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
        [ForeignKey("ProjectId")]
        public virtual Projects? Projects { get; set; }

        /// <summary>
        /// Gets or sets the user who created the task.
        /// </summary>
        [ForeignKey("CreatedUserId")]
        public virtual ProjectUser? ProjectUser { get; set; }

        /// <summary>
        /// Gets or sets the task history associated with the task.
        /// </summary>
        public virtual IEnumerable<TaskHistory>? TaskHistory { get; set; }

        /// <summary>
        /// Gets or sets the task comments associated with the task.
        /// </summary>
        public virtual IEnumerable<TaskComments>? TaskComments { get; set; }

        /// <summary>
        /// Gets or sets the task attachments associated with the task.
        /// </summary>
        public virtual IEnumerable<TaskAttachments>? TaskAttachments { get; set; }



        /// <summary>
        /// Converts an TasksDTO object to an Tasks model.
        /// </summary>
        /// <param name="taskDTO">The TasksDTO object to convert.</param>
        /// <returns>The converted Tasks model.</returns>
        public static Tasks ToTasksModel(TasksDTO tasksDto)
        {
            var task = new Tasks();
            task.Id = tasksDto.Id;
            task.Name = tasksDto.Name;
            task.ProjectId = tasksDto.ProjectId;
            task.CreatedUserId = tasksDto.CreatedUserId;
            task.Description = tasksDto.Description;
            task.Priority = tasksDto.Priority;
            task.Type = tasksDto.Type;
            task.TaskNo = tasksDto.TaskNo;
            task.Projects = tasksDto.Projects;
            task.ProjectUser = tasksDto.ProjectUser;

            return task;

        }


        /// <summary>
        /// Converts an Tasks model to an TasksDTO object.
        /// </summary>
        /// <param name="model">The tasks model to convert.</param>
        /// <returns>The converted TasksDTO object.</returns>
        public static TasksDTO ToTasksDTO(Tasks model)
        {
            var taskDTO = new TasksDTO();  
            taskDTO.Id = model.Id;
            taskDTO.Name = model.Name;
            taskDTO.ProjectId = model.ProjectId;
            taskDTO.CreatedUserId = model.CreatedUserId;
            taskDTO.Description = model.Description;
            taskDTO.TaskNo = model.TaskNo;
            taskDTO.Priority = model.Priority;
            taskDTO.Projects = model.Projects;
            taskDTO.ProjectUser =model.ProjectUser;
            taskDTO.Type = model.Type;

            return taskDTO;
        }
    }
}
