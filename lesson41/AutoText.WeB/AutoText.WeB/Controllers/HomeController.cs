﻿using AutoText.WeB.Models;
using AutoText.WeB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoText.WeB.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsersService _usersService;

        public HomeController()
        {
            _usersService = new UsersService();
        }
        public IActionResult Index()
        {
            bool isLogin = true;
            var user = _usersService.GetUserFromCookie(HttpContext);

            if(user == null) isLogin = false;

            ViewBag.IsLogin = isLogin;

            return View();
        }

        public IActionResult Privacy()
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