using BugTracker.API.DTOs.Response;
using BugTracker.BLL;
using BugTracker.BOL;
using BugTracker.DAL;
using BugTracker.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace BugTracker.Web.Controllers
{
   

    public class ProjectsController : Controller
    {
        private readonly IOrganizationsBs organizationsBs;
        public ProjectsController(IOrganizationsBs _organizationsBs)
        {
            organizationsBs = _organizationsBs;
        }

        string baseApiURL = "http://localhost:5020/api";

        /// <summary>
        /// Retrieves the list of Projects.
        /// </summary>
        /// <returns>List of Projects.</returns>
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await GetProjects();
                var viewModelList = new List<ProjectsVM>();
                foreach (var project in list)
                {
                    var viewModel = new ProjectsVM
                    {
                        Id = project.Id,
                        Name = project.Name,
                        OrgId = project.OrgId,                        
                        StartDate = project.StartDate,
                        EndDate = project.EndDate,
                        Organizations = new OrganizationsVM() { 
                            Id = project.Organizations.Id,
                            Name = project.Organizations.Name,
                            Email = project.Organizations.Email,
                            ContactNo = project.Organizations.ContactNo
                        }

                    };

                    viewModelList.Add(viewModel);
                }

                return View(viewModelList);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
        }
        /// <summary>
        /// Displays the create Project form.
        /// </summary>

        [HttpGet]
        public async Task<IActionResult> CreateNew()
        {
            try
            {
                var list = await GetOrganizations();
                ViewBag.OrganizationList = new SelectList(list, "Id", "Name");
                return View();
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();

            }
            
        }

        ///// <summary>
        ///// Handles the submission of the create Project form.
        ///// </summary>
        ///// <param name="model">The Project model to create.</param>
        [HttpPost]
        public async Task<IActionResult> CreateNew(Projects model)
        {
            try
            {
                var response = await Insert(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
            
        }

      
        /// <summary>
        /// Displays the edit Project form.
        /// </summary>
        /// <param name="id">The ID of the Project to edit.</param>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var project = await GetById(id);

                ProjectsVM projects = new ProjectsVM();
                projects.Id = project.Id;
                projects.Name = project.Name;
                projects.OrgId = project.OrgId;
                projects.StartDate = project.StartDate;
                projects.EndDate = project.EndDate;

                var list = await GetOrganizations();
                ViewBag.OrganizationList = new SelectList(list, "Id", "Name");

                return View(projects);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();

            }

            
        }

        /// <summary>
        /// Handles the submission of the edit Project form.
        /// </summary>
        /// <param name="model">The updated Project model.</param>
        [HttpPost]
        public async Task<IActionResult> Edit(Projects model)
        {
            try
            {
                var obj = await Update(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();

            }

        }

        /// <summary>
        /// Displays the details of an Project.
        /// </summary>
        /// <param name="id">The ID of the Project.</param>
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var project = await GetById(id);

                ProjectsVM projects = new ProjectsVM();

                projects.Id = project.Id;
                projects.Name = project.Name;
                projects.OrgId = project.OrgId;
                projects.StartDate = project.StartDate;
                projects.EndDate = project.EndDate;

                var list = await GetOrganizations();
                ViewBag.OrganizationList = new SelectList(list, "Id", "Name");
                return View(projects);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();

            }
           
        }

        /// <summary>
        /// Retrieves the list of Projects from the API.
        /// </summary>
        /// <returns>List of Projects.</returns>
        public async Task<List<Projects>> GetProjects()
        {
            List<Projects> list = new List<Projects>();
            string endpoint = $"{baseApiURL}/Projects/getAll";
            using (HttpClient client = new HttpClient())
            {
                using var response = await client.GetAsync(endpoint);
                string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                var result = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                if (result.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<Projects>>(result.Data.ToString());
                }

                return list;
            }
        }

        /// <summary>
        /// Inserts a new Project into the API.
        /// </summary>
        /// <param name="model">The Project model to insert.</param>
        public async Task<IActionResult> Insert(Projects model)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/Projects/create";

                StringContent content = new StringContent(JsonConvert.SerializeObject(model),
                                                             Encoding.UTF8, "application/json");

                using var response = await client.PostAsync(endpoint, content);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess) 
                    {
                        TempData["SuccessMsg"] = "Project is created";
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "Project is not  created";
                    }
                }
            }

            return View();
        }

        /// <summary>
        /// Updates an existing Project in the API.
        /// </summary>
        /// <param name="model">The updated Project model.</param>
        public async Task<IActionResult> Update(Projects model)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/Projects/update";

                StringContent content = new StringContent(JsonConvert.SerializeObject(model),
                                                             Encoding.UTF8, "application/json");

                using var response = await client.PutAsync(endpoint, content);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);
                    if (jsonResponse.IsSuccess)
                    {
                        TempData["SuccessMsg"] = "Project is update";
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "Project is not  update";
                    }
                }
               
            }

            return View();
        }

        /// <summary>
        /// Retrieves an Project by its ID.
        /// </summary>
        /// <param name="id">The ID of the Project.</param>
        /// <returns>The Project.</returns>
        public async Task<Projects> GetById(Guid id)
        {
            var Projects = new Projects();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/Projects/getById/" + id;
                using var response = await client.GetAsync(endpoint);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess)
                    {
                        Projects = JsonConvert.DeserializeObject<Projects>(jsonResponse.Data.ToString());
                    }

                    return Projects;
                }
            }
        }
        public async Task<List<Organizations>> GetOrganizations()
        {
            List<Organizations> list = new List<Organizations>();
            string endpoint = $"{baseApiURL}/Organizations/getAll";
            using (HttpClient client = new HttpClient())
            {
                using var response = await client.GetAsync(endpoint);
                string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                var result = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                if (result.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<Organizations>>(result.Data.ToString());
                }

                return list;
            }
        }
    }
}
