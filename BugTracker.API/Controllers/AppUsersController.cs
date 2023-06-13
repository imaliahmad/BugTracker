using BugTracker.API.DTOs.Request;
using BugTracker.BLL;
using BugTracker.BOL;
using BugTracker.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.API.Controllers
{
    /// <summary>
    /// Represents the controller for managing AppUsers.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUsersBs appUsersBs;

        public AppUsersController(IAppUsersBs _appUsersBs)
        {
           appUsersBs = _appUsersBs;
        }

        /// <summary>
        /// Retrieves all AppUsers
        /// </summary>
        /// <returns>The list of appusers.</returns>
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                AppUsers[] usersList = appUsersBs.GetAll().ToArray();
                List<AppUsersDTO> usersDTOList = new List<AppUsersDTO>();
                foreach(var item in usersList)
                {
                    usersDTOList.Add(AppUsersDTO.ToAppUsersDTO(item));
                }

                return Ok(usersDTOList.ToArray());
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves an appuser by ID.
        /// </summary>
        /// <param name="id">The ID of the appuser.</param>
        /// <returns>The appuser.</returns>
        [HttpGet]
        [Route("getById/{Id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var users = appUsersBs.GetById(id);
                AppUsersDTO usersDTO = AppUsersDTO.ToAppUsersDTO(users);

                return Ok(usersDTO);
            }
            catch (Exception ex)
            {
                return NotFound();
               
            }
        }

        /// <summary>
        /// Creates a new appuser.
        /// </summary>
        /// <param name="orgDTO">The appuser data.</param>
        /// <returns>The created appuser.</returns>

        [HttpPost]
        [Route("create")]
        public IActionResult Create(AppUsersDTO usersDTO)
        {
            try
            {
                AppUsers appUsers = appUsersBs.Insert(
                                         AppUsersDTO.ToAppUsersModel(usersDTO)
                                    );

                usersDTO = AppUsersDTO.ToAppUsersDTO(appUsers);

                return Ok(usersDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing appuser.
        /// </summary>
        /// <param name="orgDto">The appuser data to update.</param>
        /// <returns>The updated appuser.</returns>
        [HttpPut]
        [Route("update")]
        public IActionResult Update(AppUsersDTO usersDTO)
        {
            try
            {
                AppUsers appUsers = appUsersBs.Update(
                                         AppUsersDTO.ToAppUsersModel(usersDTO)
                                    );

                usersDTO = AppUsersDTO.ToAppUsersDTO(appUsers);

                return Ok(usersDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an appuser by ID.
        /// </summary>
        /// <param name="id">The ID of the appuser to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        [HttpDelete]
        [Route("delete/{Id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var users = appUsersBs.Delete(id);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
