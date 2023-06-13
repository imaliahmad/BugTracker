using BugTracker.BOL;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.API.DTOs.Request
{
    /// <summary>
    /// Represents the DTO for Task Comments.
    /// </summary>
    public class TaskCommentsDTO : BaseEntityDTO
    {
        /// <summary>
        /// Gets or sets the task ID (foreign key).
        /// </summary>
        public Guid TaskId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who created the comment (foreign key).
        /// </summary>
        public Guid CreatedUserId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the comment was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the description of the comment.
        /// </summary>
        public string Description { get; set; }

        // Navigations

        /// <summary>
        /// Gets or sets the task associated with the comment.
        /// </summary>
        [ForeignKey("TaskId")]
        public virtual Tasks? Tasks { get; set; }

        /// <summary>
        /// Gets or sets the user who created the comment.
        /// </summary>
        [ForeignKey("CreatedUserId")]
        public virtual ProjectUser? ProjectUser { get; set; }

        /// <summary>
        /// Converts an TaskCommentsDTO object to an TaskComments model.
        /// </summary>
        /// <param name="taskDTO">The TaskCommentsDTO object to convert.</param>
        /// <returns>The converted TaskComments model.</returns>
        public static TaskComments ToTaskCommentsModel(TaskCommentsDTO comDto)
        {
            var com = new TaskComments();
            com.Id = comDto.Id;
            com.TaskId = comDto.TaskId;
            com.CreatedUserId = comDto.CreatedUserId;
            com.CreatedDate = comDto.CreatedDate;
            com.Description = comDto.Description;
           

            return com;

        }


        /// <summary>
        /// Converts an TaskComments model to an TaskCommentsDTO object.
        /// </summary>
        /// <param name="model">The TaskComments model to convert.</param>
        /// <returns>The converted TaskCommentsDTO object.</returns>
        public static TaskCommentsDTO ToTaskCommentsDTO(TaskComments model)
        {
            var comDTO = new TaskCommentsDTO();
            comDTO.Id = model.Id;
            comDTO.TaskId = model.TaskId;
            comDTO.CreatedUserId = model.CreatedUserId;
            comDTO.CreatedDate = model.CreatedDate;
            comDTO.Description = model.Description;


            return comDTO;

        }
    }
}
