using AuthenticationAndAuthorization.Models.DTOs;
using AuthenticationAndAuthorization.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAndAuthorization.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //AspNetUsers Tablosunun manager sınıfıdır 
        //kısaca user ları yoneten sınıfıdır
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IPasswordHasher<AppUser> passwordHasher;

        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 IPasswordHasher<AppUser> passwordHasher)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.passwordHasher = passwordHasher;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            RegisterDTO registerDTO = new();
            return View(registerDTO);
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser { UserName = registerDTO.UserName, Email = registerDTO.Email };
                var result = await userManager.CreateAsync(appUser, registerDTO.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }


            return View(registerDTO);

        }
    }
}
