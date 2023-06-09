using BugTracker.API.DTOs.Request;
using BugTracker.BLL;
using BugTracker.BOL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly AppUsersBs appUsersBs;

        public AppUsersController(AppUsersBs _appUsersBs)
        {
           appUsersBs = _appUsersBs;
        }
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
    }
}
