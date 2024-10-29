﻿using Microsoft.AspNetCore.Mvc;
using SingleSong.Models;
using System.Diagnostics;

namespace SingleSong.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult CardSong()
        {
            return View();
        }
        public IActionResult Entrance()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult CardSinger()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
