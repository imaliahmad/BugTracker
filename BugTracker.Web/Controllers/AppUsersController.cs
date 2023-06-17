using BugTracker.API.DTOs.Response;
using BugTracker.BOL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BugTracker.Web.Controllers
{
    public class AppUsersController : Controller
    {
        string baseApiURL = "http://localhost:5020/api";

        /// <summary>
        /// Retrieves the list of AppUsers.
        /// </summary>
        /// <returns>List of AppUsers.</returns>
        public async Task<IActionResult> Index()
        {
           var list = await GetAppUsers();
            return View(list);
        }

        /// <summary>
        /// Displays the create AppUsers form.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        /// <summary>
        /// Handles the submission of the create  form.
        /// </summary>
        /// <param name="model">The AppUsers model to create.</param>
        [HttpPost]
        public async Task<IActionResult> Create(AppUsers model)
        {
            var obj = await Insert(model);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays the edit AppUsers form.
        /// </summary>
        /// <param name="id">The ID of the AppUsers to edit.</param>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var organization = await GetById(id);
            return View(organization);
        }

        /// <summary>
        /// Handles the submission of the edit AppUsers form.
        /// </summary>
        /// <param name="model">The updated AppUsers model.</param>
        [HttpPost]
        public async Task<IActionResult> Edit(AppUsers model)
        {
            var obj = await Update(model);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays the details of an AppUsers.
        /// </summary>
        /// <param name="id">The ID of the AppUsers.</param>
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var organization = await GetById(id);
            return View(organization);
        }

        /// <summary>
        /// Retrieves the list of AppUsers from the API.
        /// </summary>
        /// <returns>List of AppUsers.</returns>
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

        /// <summary>
        /// Inserts a new AppUsers into the API.
        /// </summary>
        /// <param name="model">The AppUsers model to insert.</param>
        public async Task<IActionResult> Insert(AppUsers model)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/AppUsers/create";

                StringContent content = new StringContent(JsonConvert.SerializeObject(model),
                                                             Encoding.UTF8, "application/json");

                using var response = await client.PostAsync(endpoint, content);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);
                }
            }

            return View();
        }

        /// <summary>
        /// Updates an existing AppUsers in the API.
        /// </summary>
        /// <param name="model">The updated AppUsers model.</param>
        public async Task<IActionResult> Update(AppUsers model)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/AppUsers/update";

                StringContent content = new StringContent(JsonConvert.SerializeObject(model),
                                                             Encoding.UTF8, "application/json");

                using var response = await client.PutAsync(endpoint, content);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);
                }
            }

            return View();
        }

        /// <summary>
        /// Retrieves an AppUsers by its ID.
        /// </summary>
        /// <param name="id">The ID of the AppUsers.</param>
        /// <returns>The AppUsers.</returns>
        public async Task<AppUsers> GetById(Guid id)
        {
            var AppUsers = new AppUsers();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/AppUsers/getById/" + id;
                using var response = await client.GetAsync(endpoint);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess)
                    {
                        AppUsers = JsonConvert.DeserializeObject<AppUsers>(jsonResponse.Data.ToString());
                    }

                    return AppUsers;
                }
            }
        }
    }
}
