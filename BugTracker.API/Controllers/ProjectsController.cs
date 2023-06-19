using BugTracker.API.DTOs.Request;
using BugTracker.API.DTOs.Response;
using BugTracker.BLL;
using BugTracker.BOL;
using BugTracker.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsBs projectsBs;
        private readonly IOrganizationsBs organizationsBs;
        public ProjectsController(IProjectsBs _projectsBs, IOrganizationsBs _organizationsBs)
        {
            projectsBs = _projectsBs;
            organizationsBs = _organizationsBs;
        }

        /// <summary>
        /// Retrieves all Projects
        /// </summary>
        /// <returns>The list of Projects.</returns>
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                Projects[] projectsList = projectsBs.GetAll().ToArray();
                List<ProjectsDTO> projectsDTOList = new List<ProjectsDTO>();
                foreach (var item in projectsList)
                {
                    projectsDTOList.Add(ProjectsDTO.ToProjectsDTO(item));
                }

                return Ok(new JsonResponse() { IsSuccess = true, Data = projectsDTOList.ToArray() });
            }
            catch (Exception ex)
            {

                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }

        /// <summary>
        /// Retrieves an projects by ID.
        /// </summary>
        /// <param name="id">The ID of the project.</param>
        /// <returns>The project.</returns>
        [HttpGet]
        [Route("getById/{Id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var projects = projectsBs.GetById(id);
                ProjectsDTO projectsDTO = ProjectsDTO.ToProjectsDTO(projects);

                return Ok(new JsonResponse() { IsSuccess = true, Data = projectsDTO });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });

            }
        }

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="orgDTO">The project data.</param>
        /// <returns>The created project.</returns>

        [HttpPost]
        [Route("create")]
        public IActionResult Create(ProjectsDTO projectsDTO)
        {
            try
            {
                Projects Projects = projectsBs.Insert(
                                         ProjectsDTO.ToProjectsModel(projectsDTO)
                                    );

                projectsDTO = ProjectsDTO.ToProjectsDTO(Projects);
          
                return Ok(new JsonResponse() { IsSuccess = true, Data = projectsDTO });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg});
            }
        }

        /// <summary>
        /// Updates an existing project.
        /// </summary>
        /// <param name="projectDto">The project data to update.</param>
        /// <returns>The updated project.</returns>
        [HttpPut]
        [Route("update")]
        public IActionResult Update(ProjectsDTO projectsDTO)
        {
            try
            {
                Projects Projects = projectsBs.Update(
                                         ProjectsDTO.ToProjectsModel(projectsDTO)
                                    );

                projectsDTO = ProjectsDTO.ToProjectsDTO(Projects);

                return Ok(new JsonResponse() { IsSuccess = true, Data = projectsDTO });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }

        /// <summary>
        /// Deletes an project by ID.
        /// </summary>
        /// <param name="id">The ID of the project to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        [HttpDelete]
        [Route("delete/{Id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var projects = projectsBs.Delete(id);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }
    }
}
