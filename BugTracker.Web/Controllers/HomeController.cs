﻿using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
