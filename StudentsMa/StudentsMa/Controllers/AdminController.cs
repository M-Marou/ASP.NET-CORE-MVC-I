using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentsMa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMa.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateRole(AdminCreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = model.RoleName
                };

                IdentityResult result = await this.roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(ListRoles));
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {

            if (id is null)
            {
                ViewBag.ErrorMessage = "There is no Role ID Selected";
                return View("NotFound");
            }
            IdentityRole role = await this.roleManager.FindByIdAsync(id);

            if (role is null)
            {
                ViewBag.ErrorMessage = $"The role ID {id} cannot be found !";
                return View("NotFound");
            }

            EditRoleViewModel model = new EditRoleViewModel()
            {
                Id = role.Id,
                RoleName = role.Name,
                Users = new List<string>()
        };

            foreach(IdentityUser user in userManager.Users)
            {
               if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.Email);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditRoleViewModel model)
        {

            if (ModelState.IsValid)
            {
                IdentityRole role = await this.roleManager.FindByIdAsync(model.Id);

                if (role is null)
                {
                    ViewBag.ErrorMessage = $"The role ID {model.Id} cannot be found !";
                    return View("NotFound");
                }

                role.Name = model.RoleName;
                IdentityResult result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(ListRoles));
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
