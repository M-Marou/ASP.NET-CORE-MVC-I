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
    [Authorize(Roles = "Admin")]
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

        [HttpGet]
        public async Task<ActionResult> EditUsersRole(string idRole)
        {
            if (string.IsNullOrEmpty(idRole))
            {
                ViewBag.ErrorMessage = $"The role must exist and not empty in the URL !";
                return View("NotFound");
            }

            IdentityRole role = await this.roleManager.FindByIdAsync(idRole);

            if (role is null)
            {
                ViewBag.ErrorMessage = $"The role ID {idRole} cannot be found !";
                return View("NotFound");
            }

            List<EditUsersRoleViewModel> Models = new List<EditUsersRoleViewModel>();

            foreach(IdentityUser user in userManager.Users)
            {
                EditUsersRoleViewModel model = new EditUsersRoleViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    IsSelected = false
                };

                if ( await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.IsSelected = true;
                }

                Models.Add(model);
            }

            ViewBag.RoleId = idRole;
            return View(Models);
        }

        [HttpPost]
        public async Task<ActionResult> EditUsersRole(List<EditUsersRoleViewModel> model, string idRole)
        {
            if (string.IsNullOrEmpty(idRole))
            {
                ViewBag.ErrorMessage = $"The role must exist and not empty in the URL !";
                return View("NotFound");
            }

            IdentityRole role = await this.roleManager.FindByIdAsync(idRole);

            if (role is null)
            {
                ViewBag.ErrorMessage = $"The role ID {idRole} cannot be found !";
                return View("NotFound");
            }

            IdentityResult result = null;

            for (int i = 0; i < model.Count; i++)
            {
                IdentityUser user = await userManager.FindByIdAsync(model[i].UserId);
                if (await userManager.IsInRoleAsync(user, role.Name) && !model[i].IsSelected)
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else if (!(await userManager.IsInRoleAsync(user, role.Name)) && model[i].IsSelected)
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }

                if (result != null && !result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            }

            return RedirectToAction(nameof(Edit), new { id = idRole });
        }
    }
}
