using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userRepository.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email is incorrect.");
                return View(model);
            }
            if (user.Password != model.Password)
            {
                ModelState.AddModelError("", "Password is incorrect.");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.Email),
                new Claim(ClaimTypes.Role, user.Role.Name),
                new Claim(ClaimTypes.UserData, user.Name),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}

//TODO genel error div i eklemek lazım
//TODO bcrypt kullanmak lazım