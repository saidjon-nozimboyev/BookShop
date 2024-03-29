﻿using Microsoft.AspNetCore.Mvc;

namespace Ustoz_Proyekti.Controllers;

public class HomeController : Controller
{
    {
        public IActionResult Index()
    {
        return View();
    }

    public IActionResult Error(string? url)
    {
        if (url == null)
        {
            url = "/";
        }
        return View("Error404", url);
    }
}
}
