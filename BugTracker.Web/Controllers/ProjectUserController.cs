using BugTracker.API.DTOs.Response;
using BugTracker.BOL;
using BugTracker.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace BugTracker.Web.Controllers
{
    public class ProjectUserController : Controller
    {
        string baseApiURL = "http://localhost:5020/api";

        /// <summary>
        /// Retrieves the list of ProjectUser.
        /// </summary>
        /// <returns>List of ProjectUser.</returns>
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await GetProjectUser();
                var viewModelList = new List<ProjectUserVM>();
                foreach (var projectuser in list)
                {
                    var viewModel = new ProjectUserVM
                    {
                        Id = projectuser.Id,
                        ProjectId = projectuser.ProjectId,
                        UserId = projectuser.UserId,
                        Projects = new Projects()
                        {
                            Id = projectuser.Projects.Id,
                            Name = projectuser.Projects.Name,
                            OrgId = projectuser.Projects.OrgId,
                            StartDate = projectuser.Projects.StartDate,
                            EndDate = projectuser.Projects.EndDate
                        },
                        AppUsers = new AppUsers()
                        {
                            Id = projectuser.AppUsers.Id,
                            Name = projectuser.AppUsers.Name,
                            OrgId = projectuser.AppUsers.OrgId,
                            Password = projectuser.AppUsers.Password,
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
        /// Displays the create ProjectUser form.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> CreateNew()
        {
            try
            {
                var list = await GetProjects();
                ViewBag.ProjectsList = new SelectList(list, "Id", "Name");

                var users = await GetAppUsers();
                ViewBag.UsersList = new SelectList(users, "Id", "Name");

                return View();
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
        }

        /// <summary>
        /// Handles the submission of the create ProjectUser form.
        /// </summary>
        /// <param name="model">The ProjectUser model to create.</param>
        [HttpPost]
        public async Task<IActionResult> CreateNew(ProjectUser model)
        {
            try
            {
                var obj = await Insert(model);

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
        /// Displays the edit ProjectUser form.
        /// </summary>
        /// <param name="id">The ID of the ProjectUser to edit.</param>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var ProjectUser = await GetById(id);

                ProjectUserVM projectUser = new ProjectUserVM();
                projectUser.Id = ProjectUser.Id;
                projectUser.ProjectId = ProjectUser.ProjectId;
                projectUser.UserId = ProjectUser.UserId;


                var list = await GetProjects();
                ViewBag.ProjectsList = new SelectList(list, "Id", "Name");

                var users = await GetAppUsers();
                ViewBag.UsersList = new SelectList(users, "Id", "Name");

                return View(projectUser);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
        }

        /// <summary>
        /// Handles the submission of the edit ProjectUser form.
        /// </summary>
        /// <param name="model">The updated ProjectUser model.</param>
        [HttpPost]
        public async Task<IActionResult> Edit(ProjectUser model)
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
        /// Displays the details of an ProjectUser.
        /// </summary>
        /// <param name="id">The ID of the ProjectUser.</param>
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var ProjectUser = await GetById(id);

                ProjectUserVM projectUser = new ProjectUserVM();
                projectUser.Id = ProjectUser.Id;
                projectUser.ProjectId = ProjectUser.ProjectId;
                projectUser.UserId = ProjectUser.UserId;

                var list = await GetProjects();
                ViewBag.ProjectsList = new SelectList(list, "Id", "Name");

                var users = await GetAppUsers();
                ViewBag.UsersList = new SelectList(users, "Id", "Name");

                return View(projectUser);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
        }

        /// <summary>
        /// Retrieves the list of ProjectUser from the API.
        /// </summary>
        /// <returns>List of ProjectUser.</returns>
        public async Task<List<ProjectUser>> GetProjectUser()
        {
            List<ProjectUser> list = new List<ProjectUser>();
            string endpoint = $"{baseApiURL}/ProjectUser/getAll";

            using (HttpClient client = new HttpClient())
            {
                using var response = await client.GetAsync(endpoint);
                string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                var result = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                if (result.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<ProjectUser>>(result.Data.ToString());
                }

                return list;
            }
        }

        /// <summary>
        /// Inserts a new ProjectUser into the API.
        /// </summary>
        /// <param name="model">The ProjectUser model to insert.</param>
        public async Task<IActionResult> Insert(ProjectUser model)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/ProjectUser/create";

                StringContent content = new StringContent(JsonConvert.SerializeObject(model),
                                                             Encoding.UTF8, "application/json");

                using var response = await client.PostAsync(endpoint, content);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess)
                    {
                        TempData["SuccessMsg"] = "ProjectUser is created";
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "ProjectUser is not  created";
                    }

                }
            }

            return View();
        }

        /// <summary>
        /// Updates an existing ProjectUser in the API.
        /// </summary>
        /// <param name="model">The updated ProjectUser model.</param>
        public async Task<IActionResult> Update(ProjectUser model)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/ProjectUser/update";

                StringContent content = new StringContent(JsonConvert.SerializeObject(model),
                                                             Encoding.UTF8, "application/json");

                using var response = await client.PutAsync(endpoint, content);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess)
                    {
                        TempData["SuccessMsg"] = "ProjectUser is update";
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "ProjectUser is not  update";
                    }
                }
            }

            return View();
        }

        /// <summary>
        /// Retrieves an ProjectUser by its ID.
        /// </summary>
        /// <param name="id">The ID of the ProjectUser.</param>
        /// <returns>The ProjectUser.</returns>
        public async Task<ProjectUser> GetById(Guid id)
        {
            var ProjectUser = new ProjectUser();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/ProjectUser/getById/" + id;
                using var response = await client.GetAsync(endpoint);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess)
                    {
                        ProjectUser = JsonConvert.DeserializeObject<ProjectUser>(jsonResponse.Data.ToString());
                    }

                    return ProjectUser;
                }
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
        /// Retrieves the list of Users from the API.
        /// </summary>
        /// <returns>List of Users.</returns>
        public async Task<List<AppUsers>> GetAppUsers()
        {
            List<AppUsers> list = new List<AppUsers>();
            string endpoint = $"{baseApiURL}/AppUsers/getAll";
            using (HttpClient client = new HttpClient())
            {
                using var response = await client.GetAsync(endpoint);
                string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                var result = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                if (result.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<AppUsers>>(result.Data.ToString());
                }

                return list;
            }
        }
    }
}

