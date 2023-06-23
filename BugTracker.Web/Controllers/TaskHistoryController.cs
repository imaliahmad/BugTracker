using BugTracker.API.DTOs.Response;
using BugTracker.BOL;
using BugTracker.BOL.DataTypes;
using BugTracker.Web.DataTypes;
using BugTracker.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Web.Controllers
{
    public class TaskHistoryController : Controller
    {
        string baseApiURL = "http://localhost:5020/api";

        /// <summary>
        /// Retrieves the list of TaskHistory.
        /// </summary>
        /// <returns>List of TaskHistory.</returns>
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await GetTaskHistory();
                var viewModelList = new List<TaskHistoryVM>();
                foreach (var taskHistory in list)
                {
                   viewModelList.Add(TaskHistoryVM.ToTaskHistoryVM(taskHistory));
                };

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
        /// Displays the create TaskHistory form.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> CreateNew()
        {
            try
            {
                var task = await GetTasks();
                ViewBag.TaskList = new SelectList(task, "Id", "Name");

                var user = await GetProjectUser();
                ViewBag.UserList = new SelectList(user, "Id", "AppUsers.Name");

                ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(StatusType)));
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
        /// Handles the submission of the create TaskHistory form.
        /// </summary>
        /// <param name="model">The TaskHistory model to create.</param>
        [HttpPost]
        public async Task<IActionResult> CreateNew(TaskHistory model)
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
        /// Displays the edit TaskHistory form.
        /// </summary>
        /// <param name="id">The ID of the TaskHistory to edit.</param>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var TaskHistory = await GetById(id);

                TaskHistoryVM taskHistoryVM = new TaskHistoryVM();
                taskHistoryVM = TaskHistoryVM.ToTaskHistoryVM(TaskHistory);

                var task = await GetTasks();
                ViewBag.TaskList = new SelectList(task, "Id", "Name");

                var user = await GetProjectUser();
                ViewBag.UserList = new SelectList(user, "Id", "AppUsers.Name");

                ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(StatusType)));

                return View(taskHistoryVM);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
        }

        /// <summary>
        /// Handles the submission of the edit TaskHistory form.
        /// </summary>
        /// <param name="model">The updated TaskHistory model.</param>
        [HttpPost]
        public async Task<IActionResult> Edit(TaskHistory model)
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
        /// Displays the details of an TaskHistory.
        /// </summary>
        /// <param name="id">The ID of the TaskHistory.</param>
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var TaskHistory = await GetById(id);

                TaskHistoryVM taskHistoryVM = new TaskHistoryVM();
                taskHistoryVM = TaskHistoryVM.ToTaskHistoryVM(TaskHistory);

                var task = await GetTasks();
                ViewBag.TaskList = new SelectList(task, "Id", "Name");

                var user = await GetProjectUser();
                ViewBag.UserList = new SelectList(user, "Id", "AppUsers.Name");

                ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(StatusType)));

                return View(taskHistoryVM);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
        }

        /// <summary>
        /// Retrieves the list of TaskHistory from the API.
        /// </summary>
        /// <returns>List of TaskHistory.</returns>
        public async Task<List<TaskHistory>> GetTaskHistory()
        {
            List<TaskHistory> list = new List<TaskHistory>();
            string endpoint = $"{baseApiURL}/TaskHistory/getAll";
            using (HttpClient client = new HttpClient())
            {
                using var response = await client.GetAsync(endpoint);
                string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                var result = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                if (result.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<TaskHistory>>(result.Data.ToString());
                }

                return list;
            }
        }

        /// <summary>
        /// Inserts a new TaskHistory into the API.
        /// </summary>
        /// <param name="model">The TaskHistory model to insert.</param>
        public async Task<IActionResult> Insert(TaskHistory model)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/TaskHistory/create";

                StringContent content = new StringContent(JsonConvert.SerializeObject(model),
                                                             Encoding.UTF8, "application/json");

                using var response = await client.PostAsync(endpoint, content);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess)
                    {
                        TempData["SuccessMsg"] = "TaskHistory is created";
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "TaskHistory is not  created";
                    }

                }
            }

            return View();
        }

        /// <summary>
        /// Updates an existing TaskHistory in the API.
        /// </summary>
        /// <param name="model">The updated TaskHistory model.</param>
        public async Task<IActionResult> Update(TaskHistory model)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/TaskHistory/update";

                StringContent content = new StringContent(JsonConvert.SerializeObject(model),
                                                             Encoding.UTF8, "application/json");

                using var response = await client.PutAsync(endpoint, content);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess)
                    {
                        TempData["SuccessMsg"] = "TaskHistory is update";
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "TaskHistory is not  update";
                    }
                }
            }

            return View();
        }

        /// <summary>
        /// Retrieves an TaskHistory by its ID.
        /// </summary>
        /// <param name="id">The ID of the TaskHistory.</param>
        /// <returns>The TaskHistory.</returns>
        public async Task<TaskHistory> GetById(Guid id)
        {
            var TaskHistory = new TaskHistory();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/TaskHistory/getById/" + id;
                using var response = await client.GetAsync(endpoint);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess)
                    {
                        TaskHistory = JsonConvert.DeserializeObject<TaskHistory>(jsonResponse.Data.ToString());
                    }

                    return TaskHistory;
                }
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
