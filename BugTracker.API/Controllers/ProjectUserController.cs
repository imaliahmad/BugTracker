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
    public class ProjectUserController : ControllerBase
    {
        private readonly IProjectUserBs ProjectUserBs;

        public ProjectUserController(IProjectUserBs _ProjectUserBs)
        {
            ProjectUserBs = _ProjectUserBs;
        }

        /// <summary>
        /// Retrieves all ProjectUser
        /// </summary>
        /// <returns>The list of ProjectUser.</returns>
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                ProjectUser[] usersList = ProjectUserBs.GetAll().ToArray();
                List<ProjectUsersDTO> usersDTOList = new List<ProjectUsersDTO>();
                foreach (var item in usersList)
                {
                    usersDTOList.Add(ProjectUsersDTO.ToProjectUsersDTO(item));
                }

                return Ok(new JsonResponse() { IsSuccess = true, Data = usersDTOList.ToArray() });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves an projectuser by ID.
        /// </summary>
        /// <param name="id">The ID of the projectuser.</param>
        /// <returns>The projectuser.</returns>
        [HttpGet]
        [Route("getById/{Id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var users = ProjectUserBs.GetById(id);
                ProjectUsersDTO usersDTO = ProjectUsersDTO.ToProjectUsersDTO(users);

                return Ok(new JsonResponse() { IsSuccess = true, Data = usersDTO });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });

            }
        }

        /// <summary>
        /// Creates a new projectuser.
        /// </summary>
        /// <param name="projectuserDTO">The projectuser data.</param>
        /// <returns>The created projectuser.</returns>

        [HttpPost]
        [Route("create")]
        public IActionResult Create(ProjectUsersDTO usersDTO)
        {
            try
            {
                ProjectUser ProjectUser = ProjectUserBs.Insert(
                                         ProjectUsersDTO.ToProjectUsersModel(usersDTO)
                                    );

                usersDTO = ProjectUsersDTO.ToProjectUsersDTO(ProjectUser);

                return Ok(new JsonResponse() { IsSuccess = true, Data = usersDTO });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }

        /// <summary>
        /// Updates an existing projectuser.
        /// </summary>
        /// <param name="orgDto">The projectuser data to update.</param>
        /// <returns>The updated projectuser.</returns>
        [HttpPut]
        [Route("update")]
        public IActionResult Update(ProjectUsersDTO usersDTO)
        {
            try
            {
                ProjectUser ProjectUser = ProjectUserBs.Update(
                                         ProjectUsersDTO.ToProjectUsersModel(usersDTO)
                                    );

                usersDTO = ProjectUsersDTO.ToProjectUsersDTO(ProjectUser);

                return Ok(new JsonResponse() { IsSuccess = true, Data = usersDTO });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }

        /// <summary>
        /// Deletes an projectuser by ID.
        /// </summary>
        /// <param name="id">The ID of the projectuser to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        [HttpDelete]
        [Route("delete/{Id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var users = ProjectUserBs.Delete(id);

                return Ok(users);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }
    }
}
