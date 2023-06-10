using BugTracker.API.DTOs.Request;
using BugTracker.BLL;
using BugTracker.BOL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsBs ProjectsBs;

        public ProjectsController(IProjectsBs _ProjectsBs)
        {
            ProjectsBs = _ProjectsBs;
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
                Projects[] projectsList = ProjectsBs.GetAll().ToArray();
                List<ProjectsDTO> projectsDTOList = new List<ProjectsDTO>();
                foreach (var item in projectsList)
                {
                    projectsDTOList.Add(ProjectsDTO.ToProjectsDTO(item));
                }

                return Ok(projectsDTOList.ToArray());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
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
                var users = ProjectsBs.GetById(id);
                ProjectsDTO usersDTO = ProjectsDTO.ToProjectsDTO(users);

                return Ok(usersDTO);
            }
            catch (Exception ex)
            {
                return NotFound();

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
                Projects Projects = ProjectsBs.Insert(
                                         ProjectsDTO.ToProjectsModel(projectsDTO)
                                    );

                projectsDTO = ProjectsDTO.ToProjectsDTO(Projects);

                return Ok(projectsDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing project.
        /// </summary>
        /// <param name="orgDto">The project data to update.</param>
        /// <returns>The updated project.</returns>
        [HttpPut]
        [Route("update")]
        public IActionResult Update(ProjectsDTO projectsDTO)
        {
            try
            {
                Projects Projects = ProjectsBs.Update(
                                         ProjectsDTO.ToProjectsModel(projectsDTO)
                                    );

                projectsDTO = ProjectsDTO.ToProjectsDTO(Projects);

                return Ok(projectsDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an project by ID.
        /// </summary>
        /// <param name="id">The ID of the project to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var users = ProjectsBs.Delete(id);

                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
