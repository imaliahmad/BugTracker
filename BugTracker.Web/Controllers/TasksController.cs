using BugTracker.API.DTOs.Response;
using BugTracker.BOL;
using BugTracker.BOL.DataTypes;
using BugTracker.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace BugTracker.Web.Controllers
{
    public class TasksController : Controller
    {
        string baseApiURL = "http://localhost:5020/api";

        /// <summary>
        /// Retrieves the list of Tasks.
        /// </summary>
        /// <returns>List of Tasks.</returns>
        public async Task<IActionResult> Index()
        {
            try
            { 
                //logical ==> debugging 
                var list = await GetTasks();
                var viewModelList = new List<TasksVM>();
                foreach (var task in list)
                {
                    viewModelList.Add(TasksVM.ToTasksVM(task));
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
        /// Displays the create Task form.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> CreateNew()
        {
            try
            {
                var list = await GetProjects();
                ViewBag.ProjectsList = new SelectList(list, "Id", "Name");

                var user = await GetProjectUser();
                ViewBag.ProjectUserList = new SelectList(user, "Id", "AppUsers.Name");

                ViewBag.PriorityList = new SelectList(Enum.GetValues(typeof(PriorityTypes)));
                ViewBag.TypeList = new SelectList(Enum.GetValues(typeof(TaskTypes)));

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
        /// Handles the submission of the create Task form.
        /// </summary>
        /// <param name="model">The Task model to create.</param>
        [HttpPost]
        public async Task<IActionResult> CreateNew(Tasks model)
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
        /// Displays the edit Task form.
        /// </summary>
        /// <param name="id">The ID of the Task to edit.</param>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var Task = await GetById(id);

                TasksVM tasksVM = new TasksVM();
                tasksVM = TasksVM.ToTasksVM(Task);

                var list = await GetProjects();
                ViewBag.ProjectsList = new SelectList(list, "Id", "Name");

                var user = await GetProjectUser();
                ViewBag.ProjectUserList = new SelectList(user, "Id", "AppUsers.Name");

                ViewBag.PriorityList = new SelectList(Enum.GetValues(typeof(PriorityTypes)));
                ViewBag.TypeList = new SelectList(Enum.GetValues(typeof(TaskTypes)));

                return View(tasksVM);

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
        }

        /// <summary>
        /// Handles the submission of the edit Task form.
        /// </summary>
        /// <param name="model">The updated Task model.</param>
        [HttpPost]
        public async Task<IActionResult> Edit(Tasks model)
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
        /// Displays the details of an Task.
        /// </summary>
        /// <param name="id">The ID of the Task.</param>
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var Task = await GetById(id);

                TasksVM tasksVM = new TasksVM();
                tasksVM = TasksVM.ToTasksVM(Task);

                var list = await GetProjects();
                ViewBag.ProjectsList = new SelectList(list, "Id", "Name");

                var user = await GetProjectUser();
                ViewBag.ProjectUserList = new SelectList(user, "Id", "AppUsers.Name");

                ViewBag.PriorityList = new SelectList(Enum.GetValues(typeof(PriorityTypes)));
                ViewBag.TypeList = new SelectList(Enum.GetValues(typeof(TaskTypes)));

                return View(tasksVM);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
        }

        /// <summary>
        /// Retrieves the list of Tasks from the API.
        /// </summary>
        /// <returns>List of Tasks.</returns>
        public async Task<List<Tasks>> GetTasks()
        {
            List<Tasks> list = new List<Tasks>();
            string endpoint = $"{baseApiURL}/Tasks/getAll";
            using (HttpClient client = new HttpClient())
            {
                using var response = await client.GetAsync(endpoint);
                string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                var result = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                if (result.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<Tasks>>(result.Data.ToString());
                }

                return list;
            }
        }

        /// <summary>
        /// Inserts a new Task into the API.
        /// </summary>
        /// <param name="model">The Task model to insert.</param>
        public async Task<IActionResult> Insert(Tasks model)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/Tasks/create";

                StringContent content = new StringContent(JsonConvert.SerializeObject(model),
                                                             Encoding.UTF8, "application/json");

                using var response = await client.PostAsync(endpoint, content);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess)
                    {
                        TempData["SuccessMsg"] = "Task is created";
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "Task is not  created";
                    }

                }
            }

            return View();
        }

        /// <summary>
        /// Updates an existing Task in the API.
        /// </summary>
        /// <param name="model">The updated Task model.</param>
        public async Task<IActionResult> Update(Tasks model)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/Tasks/update";

                StringContent content = new StringContent(JsonConvert.SerializeObject(model),
                                                             Encoding.UTF8, "application/json");

                using var response = await client.PutAsync(endpoint, content);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess)
                    {
                        TempData["SuccessMsg"] = "Task is update";
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "Task is not  update";
                    }
                }
            }

            return View();
        }

        /// <summary>
        /// Retrieves an Task by its ID.
        /// </summary>
        /// <param name="id">The ID of the Task.</param>
        /// <returns>The Task.</returns>
        public async Task<Tasks> GetById(Guid id)
        {
            var Tasks = new Tasks();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/Tasks/getById/" + id;
                using var response = await client.GetAsync(endpoint);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess)
                    {
                        Tasks = JsonConvert.DeserializeObject<Tasks>(jsonResponse.Data.ToString());
                    }

                    return Tasks;
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
    }
}
