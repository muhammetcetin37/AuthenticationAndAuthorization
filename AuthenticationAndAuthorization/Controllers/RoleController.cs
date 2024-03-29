﻿using AuthenticationAndAuthorization.Models.DTOs;
using AuthenticationAndAuthorization.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationAndAuthorization.Controllers
{
    [Authorize(Roles = "admin")]
    [Authorize(Roles = "manager")]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()

        {
            return View(roleManager.Roles.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Required(ErrorMessage ="Role Alanı Zorunludur")]
            [MinLength(3,ErrorMessage ="En az 3 karakter olmalıdır")]
            string name)
        {
            if (ModelState.IsValid)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(name));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(name);
        }
        public async Task<IActionResult> AssignedUser(string Id)
        {
            IdentityRole identityRole = await roleManager.FindByIdAsync(Id);
            List<AppUser> hasRole = new List<AppUser>();
            List<AppUser> HasNotRole = new List<AppUser>();
            foreach (AppUser user in userManager.Users)
            {
                //var list = await userManager.IsInRoleAsync(user, identityRole.Name) ? hasRole : hasNotRole;
                //list.Add(user);
                bool sonuc = await userManager.IsInRoleAsync(user, identityRole.Name);
                if (sonuc)
                {
                    hasRole.Add(user);
                }
                else
                {
                    HasNotRole.Add(user);
                }

            }
            AssignedRoleDTO assignedRoleDTO = new AssignedRoleDTO
            {
                Role = identityRole,
                HasRole = hasRole,
                HasNotRole = HasNotRole,
                RoleName = identityRole.Name
            };
            return View(assignedRoleDTO);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignedUser(AssignedRoleDTO roleDTO)
        {
            IdentityResult result;
            string[] addIds = roleDTO.AddIds;
            string[] delIds = roleDTO.DeleteIds;

            if (addIds != null)
            {
                foreach (var userId in addIds)
                {
                    AppUser user = await userManager.FindByIdAsync(userId);
                    result = await userManager.AddToRoleAsync(user, roleDTO.RoleName);

                }
            }

            if (delIds != null)
            {
                foreach (var userId in delIds)
                {
                    AppUser user = await userManager.FindByIdAsync(userId);
                    result = await userManager.RemoveFromRoleAsync(user, roleDTO.RoleName);

                }
            }

            return RedirectToAction("Index");
        }
    }
}
