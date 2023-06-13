using BugTracker.API.DTOs.Request;
using BugTracker.BLL;
using BugTracker.BOL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAttachmentsController : ControllerBase
    {
        private readonly ITaskAttachmentsBs TaskAttachmentsBs;

        public TaskAttachmentsController(ITaskAttachmentsBs _TaskAttachmentsBs)
        {
            TaskAttachmentsBs = _TaskAttachmentsBs;
        }

        /// <summary>
        /// Retrieves all TaskAttachments
        /// </summary>
        /// <returns>The list of TaskAttachments.</returns>
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                TaskAttachments[] TaskAttachmentsList = TaskAttachmentsBs.GetAll().ToArray();
                List<TaskAttachmentsDTO> TaskAttachmentsDTOList = new List<TaskAttachmentsDTO>();
                foreach (var item in TaskAttachmentsList)
                {
                    TaskAttachmentsDTOList.Add(TaskAttachmentsDTO.ToTaskAttachmentsDTO(item));
                }

                return Ok(TaskAttachmentsDTOList.ToArray());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves an TaskAttachments by ID.
        /// </summary>
        /// <param name="id">The ID of the TaskAttachments.</param>
        /// <returns>The TaskAttachments.</returns>
        [HttpGet]
        [Route("getById/{Id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var TaskAttachments = TaskAttachmentsBs.GetById(id);
                TaskAttachmentsDTO TaskAttachmentsDTO = TaskAttachmentsDTO.ToTaskAttachmentsDTO(TaskAttachments);

                return Ok(TaskAttachmentsDTO);
            }
            catch (Exception ex)
            {
                return NotFound();

            }
        }

        /// <summary>
        /// Creates a new TaskAttachments.
        /// </summary>
        /// <param name="taskAttachmentsDTO">The TaskAttachments Data.</param>
        /// <returns>The created TaskAttachments.</returns>

        [HttpPost]
        [Route("create")]
        public IActionResult Create(TaskAttachmentsDTO TaskAttachmentsDTO)
        {
            try
            {
                TaskAttachments taskAttachments = TaskAttachmentsBs.Insert(
                                                     TaskAttachmentsDTO.ToTaskAttachmentsModel(TaskAttachmentsDTO)
                                                  );

                TaskAttachmentsDTO = TaskAttachmentsDTO.ToTaskAttachmentsDTO(taskAttachments);

                return Ok(TaskAttachmentsDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing TaskAttachments.
        /// </summary>
        /// <param name="taskDto">The TaskAttachments data to update.</param>
        /// <returns>The updated TaskAttachments.</returns>
        [HttpPut]
        [Route("update")]
        public IActionResult Update(TaskAttachmentsDTO TaskAttachmentsDTO)
        {
            try
            {
                TaskAttachments taskAttachments = TaskAttachmentsBs.Update(
                                                    TaskAttachmentsDTO.ToTaskAttachmentsModel(TaskAttachmentsDTO)
                                                  );

                TaskAttachmentsDTO = TaskAttachmentsDTO.ToTaskAttachmentsDTO(taskAttachments);

                return Ok(TaskAttachmentsDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an TaskAttachments by ID.
        /// </summary>
        /// <param name="id">The ID of the TaskAttachment to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        [HttpDelete]
        [Route("delete/{Id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var users = TaskAttachmentsBs.Delete(id);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
