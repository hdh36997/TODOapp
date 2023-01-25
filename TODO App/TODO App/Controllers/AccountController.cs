using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO_App.Models;

namespace TODO_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;  //serwis logowania
        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel userRegister)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegister);
            }

            var newUser = new UserModel
            {
                Email = userRegister.Email,
                UserName = userRegister.Login
            };

            await _userManager.CreateAsync(newUser, userRegister.Password);


            return RedirectToAction("Index", "Task");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel userLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(userLogin);
            }

            var newUser = new UserModel
            {
                UserName = userLogin.Login
            };

            await _signInManager.PasswordSignInAsync(userLogin.Login, userLogin.Password, false, false);

            return RedirectToAction("Index", "Task");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Task");
        }


    }
}
