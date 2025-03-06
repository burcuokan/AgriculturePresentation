using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_AgriculturePresentation.Models;

namespace Project_AgriculturePresentation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.username, loginViewModel.password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> SignUp(RegisterViewModel registerViewModel)
        {
            // IdentityUser oluşturuluyor.
            IdentityUser ıdentityUser = new IdentityUser()
            {
                Id = "1",
                UserName = registerViewModel.userName,
                Email = registerViewModel.mail                                
            };
            // Şifre doğrulaması yapılıyor.
            if (registerViewModel.password==registerViewModel.passwordConfirm)
            {
                var result = await _userManager.CreateAsync(ıdentityUser, registerViewModel.password);

                if (result.Succeeded)  // Kayıt başarılı ise yönlendirme yapılır.
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)   // Kayıt başarısız olursa hata mesajları eklenir.
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(registerViewModel);   // Şifre eşleşmediğinde veya başka bir hata durumunda tekrar SignUp sayfası gösterilir.
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
