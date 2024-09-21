using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using technical_service_tracking_system.Models;
using technical_service_tracking_system.Repository.Abstract;

namespace technical_service_tracking_system.Controllers
{
    public class AccountController(
        IUserRepository userRepository
    ) : Controller
    {
        private readonly IUserRepository _userRepository = userRepository;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(!ModelState.IsValid) return View(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid) return View(model);
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {
            return View();
        }
    }
}