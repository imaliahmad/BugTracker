using BugTracker.API.DTOs.Request;
using BugTracker.BLL;
using BugTracker.BOL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCommentsController : ControllerBase
    {
        private readonly ITaskCommentsBs TaskCommentsBs;

        public TaskCommentsController(ITaskCommentsBs _TaskCommentsBs)
        {
            TaskCommentsBs = _TaskCommentsBs;
        }

        /// <summary>
        /// Retrieves all TaskComments
        /// </summary>
        /// <returns>The list of TaskComments.</returns>
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                TaskComments[] TaskCommentsList = TaskCommentsBs.GetAll().ToArray();
                List<TaskCommentsDTO> TaskCommentsDTOList = new List<TaskCommentsDTO>();
                foreach (var item in TaskCommentsList)
                {
                    TaskCommentsDTOList.Add(TaskCommentsDTO.ToTaskCommentsDTO(item));
                }

                return Ok(TaskCommentsDTOList.ToArray());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves an TaskComments by ID.
        /// </summary>
        /// <param name="id">The ID of the TaskComments.</param>
        /// <returns>The TaskComments.</returns>
        [HttpGet]
        [Route("getById/{Id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var comments = TaskCommentsBs.GetById(id);
                TaskCommentsDTO commentsDTO = TaskCommentsDTO.ToTaskCommentsDTO(comments);

                return Ok(commentsDTO);
            }
            catch (Exception ex)
            {
                return NotFound();

            }
        }

        /// <summary>
        /// Creates a new TaskComments.
        /// </summary>
        /// <param name="taskDTO">The TaskComments data.</param>
        /// <returns>The created TaskComments.</returns>

        [HttpPost]
        [Route("create")]
        public IActionResult Create(TaskCommentsDTO TaskCommentsDTO)
        {
            try
            {
                TaskComments TaskComments = TaskCommentsBs.Insert(
                                         TaskCommentsDTO.ToTaskCommentsModel(TaskCommentsDTO)
                                    );

                TaskCommentsDTO = TaskCommentsDTO.ToTaskCommentsDTO(TaskComments);

                return Ok(TaskCommentsDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing TaskComments.
        /// </summary>
        /// <param name="taskDto">The TaskComments data to update.</param>
        /// <returns>The updated TaskComments.</returns>
        [HttpPut]
        [Route("update")]
        public IActionResult Update(TaskCommentsDTO TaskCommentsDTO)
        {
            try
            {
                TaskComments TaskComments = TaskCommentsBs.Update(
                                         TaskCommentsDTO.ToTaskCommentsModel(TaskCommentsDTO)
                                    );

                TaskCommentsDTO = TaskCommentsDTO.ToTaskCommentsDTO(TaskComments);

                return Ok(TaskCommentsDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an TaskComments by ID.
        /// </summary>
        /// <param name="id">The ID of the TaskComments to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        [HttpDelete]
        [Route("delete/{Id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var users = TaskCommentsBs.Delete(id);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
