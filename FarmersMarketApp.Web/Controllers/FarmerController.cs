﻿using Microsoft.AspNetCore.Mvc;

namespace FarmersMarketApp.Web.Controllers
{
    public class FarmerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
