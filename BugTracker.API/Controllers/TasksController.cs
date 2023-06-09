﻿using BugTracker.API.DTOs.Request;
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
    public class TasksController : ControllerBase
    {
        private readonly ITasksBs TasksBs;

        public TasksController(ITasksBs _TasksBs)
        {
            TasksBs = _TasksBs;
        }

        /// <summary>
        /// Retrieves all Tasks
        /// </summary>
        /// <returns>The list of Tasks.</returns>
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                Tasks[] TasksList = TasksBs.GetAll().ToArray();
                List<TasksDTO> TasksDTOList = new List<TasksDTO>();
                foreach (var item in TasksList)
                {
                    TasksDTOList.Add(TasksDTO.ToTasksDTO(item));
                }

                return Ok(new JsonResponse() { IsSuccess = true, Data = TasksDTOList.ToArray() });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }

        /// <summary>
        /// Retrieves an Tasks by ID.
        /// </summary>
        /// <param name="id">The ID of the task.</param>
        /// <returns>The task.</returns>
        [HttpGet]
        [Route("getById/{Id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var tasks = TasksBs.GetById(id);
                TasksDTO tasksDTO = TasksDTO.ToTasksDTO(tasks);

                return Ok(new JsonResponse() { IsSuccess = true, Data = tasksDTO });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });

            }
        }

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="taskDTO">The task data.</param>
        /// <returns>The created task.</returns>

        [HttpPost]
        [Route("create")]
        public IActionResult Create(TasksDTO TasksDTO)
        {
            try
            {
                Tasks Tasks = TasksBs.Insert(
                                     TasksDTO.ToTasksModel(TasksDTO)
                              );

                TasksDTO = TasksDTO.ToTasksDTO(Tasks);

                return Ok(new JsonResponse() { IsSuccess = true, Data = TasksDTO });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }

        /// <summary>
        /// Updates an existing task.
        /// </summary>
        /// <param name="taskDto">The task data to update.</param>
        /// <returns>The updated task.</returns>
        [HttpPut]
        [Route("update")]
        public IActionResult Update(TasksDTO TasksDTO)
        {
            try
            {
                Tasks Tasks = TasksBs.Update(
                                       TasksDTO.ToTasksModel(TasksDTO)
                               );

                TasksDTO = TasksDTO.ToTasksDTO(Tasks);

                return Ok(new JsonResponse() { IsSuccess = true, Data = TasksDTO });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }

        /// <summary>
        /// Deletes an task by ID.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        [HttpDelete]
        [Route("delete/{Id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var users = TasksBs.Delete(id);
                return Ok(new JsonResponse() { IsSuccess = true, Data = users });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }
    }
}
