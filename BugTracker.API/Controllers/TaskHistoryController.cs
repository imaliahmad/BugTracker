using BugTracker.API.DTOs.Request;
using BugTracker.API.DTOs.Response;
using BugTracker.BLL;
using BugTracker.BOL;
using BugTracker.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskHistoryController : ControllerBase
    {
        private readonly ITaskHistoryBs TaskHistoryBs;

        public TaskHistoryController(ITaskHistoryBs _TaskHistoryBs)
        {
            TaskHistoryBs = _TaskHistoryBs;
        }

        /// <summary>
        /// Retrieves all TaskHistory
        /// </summary>
        /// <returns>The list of TaskHistory.</returns>
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                TaskHistory[] TaskHistoryList = TaskHistoryBs.GetAll().ToArray();
                List<TaskHistoryDTO> TaskHistoryDTOList = new List<TaskHistoryDTO>();
                foreach (var item in TaskHistoryList)
                {
                    TaskHistoryDTOList.Add(TaskHistoryDTO.ToTaskHistoryDTO(item));
                }

                return Ok(new JsonResponse() { IsSuccess = true, Data = TaskHistoryDTOList.ToArray() });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }

        /// <summary>
        /// Retrieves an TaskHistory by ID.
        /// </summary>
        /// <param name="id">The ID of the taskHistory.</param>
        /// <returns>The taskHistory.</returns>
        [HttpGet]
        [Route("getById/{Id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var taskHistory = TaskHistoryBs.GetById(id);
                TaskHistoryDTO taskHistoryDTO = TaskHistoryDTO.ToTaskHistoryDTO(taskHistory);

                return Ok(new JsonResponse() { IsSuccess = true, Data = taskHistoryDTO });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });

            }
        }

        /// <summary>
        /// Creates a new taskHistory.
        /// </summary>
        /// <param name="taskHistoryDTO">The taskHistory data.</param>
        /// <returns>The created taskHistory.</returns>

        [HttpPost]
        [Route("create")]
        public IActionResult Create(TaskHistoryDTO TaskHistoryDTO)
        {
            try
            {
                TaskHistory TaskHistory = TaskHistoryBs.Insert(
                                            TaskHistoryDTO.ToTaskHistoryModel(TaskHistoryDTO)
                                          );

                TaskHistoryDTO = TaskHistoryDTO.ToTaskHistoryDTO(TaskHistory);

                return Ok(new JsonResponse() { IsSuccess = true, Data = TaskHistoryDTO });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }

        /// <summary>
        /// Updates an existing taskHistory.
        /// </summary>
        /// <param name="taskDto">The taskHistory data to update.</param>
        /// <returns>The updated taskHistory.</returns>
        [HttpPut]
        [Route("update")]
        public IActionResult Update(TaskHistoryDTO TaskHistoryDTO)
        {
            try
            {
                TaskHistory TaskHistory = TaskHistoryBs.Update(
                                            TaskHistoryDTO.ToTaskHistoryModel(TaskHistoryDTO)
                                          );

                TaskHistoryDTO = TaskHistoryDTO.ToTaskHistoryDTO(TaskHistory);

                return Ok(new JsonResponse() { IsSuccess = true, Data = TaskHistoryDTO });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }

        /// <summary>
        /// Deletes an taskHistory by ID.
        /// </summary>
        /// <param name="id">The ID of the taskHistory to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        [HttpDelete]
        [Route("delete/{Id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var taskHistory = TaskHistoryBs.Delete(id);
                return Ok(new JsonResponse() { IsSuccess = true, Data = taskHistory });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }
    }
}
