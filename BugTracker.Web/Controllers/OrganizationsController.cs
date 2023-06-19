using BugTracker.BOL;
using BugTracker.Web.Models;
using BugTracker.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Unicode;

namespace BugTracker.Web.Controllers
{
    public class OrganizationsController : Controller
    {
        string baseApiURL = "http://localhost:5020/api";

        /// <summary>
        /// Retrieves the list of organizations.
        /// </summary>
        /// <returns>List of organizations.</returns>
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await GetOrganizations();
                var viewModelList = new List<OrganizationsVM>();
                foreach (var org in list)
                {
                    var viewModel = new OrganizationsVM
                    {
                        Id = org.Id,
                        Name = org.Name,
                        Email = org.Email,
                        ContactNo = org.ContactNo,
                        
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
        /// Displays the create organization form.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> CreateNew()
        {
            try
            {
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
        /// Handles the submission of the create organization form.
        /// </summary>
        /// <param name="model">The organization model to create.</param>
        [HttpPost]
        public async Task<IActionResult> CreateNew(Organizations model)
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
        /// Displays the edit organization form.
        /// </summary>
        /// <param name="id">The ID of the organization to edit.</param>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var organization = await GetById(id);

                OrganizationsVM organizations = new OrganizationsVM();
                organizations.Id = organization.Id; 
                organizations.Name = organization.Name;
                organizations.Email =organizations.Email;
                organizations.ContactNo = organization.ContactNo;

                return View(organizations);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
        }

        /// <summary>
        /// Handles the submission of the edit organization form.
        /// </summary>
        /// <param name="model">The updated organization model.</param>
        [HttpPost]
        public async Task<IActionResult> Edit(Organizations model)
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
        /// Displays the details of an organization.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var organization = await GetById(id);

                OrganizationsVM organizations = new OrganizationsVM();
                organizations.Id = organization.Id;
                organizations.Name = organization.Name;
                organizations.Email = organizations.Email;
                organizations.ContactNo = organization.ContactNo;

                return View(organizations);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
        }

        /// <summary>
        /// Retrieves the list of organizations from the API.
        /// </summary>
        /// <returns>List of organizations.</returns>
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

        /// <summary>
        /// Inserts a new organization into the API.
        /// </summary>
        /// <param name="model">The organization model to insert.</param>
        public async Task<IActionResult> Insert(Organizations model)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/Organizations/create";

                StringContent content = new StringContent(JsonConvert.SerializeObject(model),
                                                             Encoding.UTF8, "application/json");

                using var response = await client.PostAsync(endpoint, content);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess)
                    {
                        TempData["SuccessMsg"] = "Organization is created";
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "Organization is not  created";
                    }

                }
            }

            return View();
        }

        /// <summary>
        /// Updates an existing organization in the API.
        /// </summary>
        /// <param name="model">The updated organization model.</param>
        public async Task<IActionResult> Update(Organizations model)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/Organizations/update";

                StringContent content = new StringContent(JsonConvert.SerializeObject(model),
                                                             Encoding.UTF8, "application/json");

                using var response = await client.PutAsync(endpoint, content);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess)
                    {
                        TempData["SuccessMsg"] = "Organization is update";
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "Organization is not  update";
                    }
                }
            }

            return View();
        }

        /// <summary>
        /// Retrieves an organization by its ID.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <returns>The organization.</returns>
        public async Task<Organizations> GetById(Guid id)
        {
            var Organizations = new Organizations();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseApiURL}/Organizations/getById/" + id;
                using var response = await client.GetAsync(endpoint);
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();

                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr);

                    if (jsonResponse.IsSuccess)
                    {
                        Organizations = JsonConvert.DeserializeObject<Organizations>(jsonResponse.Data.ToString());
                    }

                    return Organizations;
                }
            }
        }
    }
}
