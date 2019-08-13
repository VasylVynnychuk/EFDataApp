using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFDataApp.Models;
using EFDataApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace EFDataApp.Controllers
{
    public class AccountController : Controller
    {
        private MobileContext _context;

        public AccountController(MobileContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Student student = await _context.Students.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (student != null)
                {
                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Students");
                }
                ModelState.AddModelError("", "Nieprawidłowy login i (lub) hasło");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Student student = await _context.Students.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (student == null)
                {
                    student = new Student
                    {
                        Email = model.Email,
                        Password = model.Password,
                        Imie = model.Imie,
                        Nazwisko = model.Nazwisko,
                        Ulica = model.Ulica,
                        Kod_pocztowy = model.Kod_pocztowy,
                        Miejscowosc = model.Miejscowosc
                    };
                    _context.Students.Add(student);
                    //_context.Students.Add(new Student { Email = model.Email, Password = model.Password });
                    await _context.SaveChangesAsync();
                    await Authenticate(model.Email);

                    return RedirectToAction("Index", "Students");
                }
                else
                    ModelState.AddModelError("", "Nieprawidłowy login i (lub) hasło");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}