﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica_WebMaster.Areas.Identity.Data;
using PruebaTecnica_WebMaster.Data;
using PruebaTecnica_WebMaster.Models.UserManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_WebMaster.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UserManagerController : Controller
    {
        private readonly UserManager<PruebaTecnica_WebMasterUser> _userManager;
        public UserManagerController(UserManager<PruebaTecnica_WebMasterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModel = new List<UserViewModel>();
            foreach (PruebaTecnica_WebMasterUser user in users)
            {
                var thisViewModel = new UserViewModel();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.Create = user.Create;
                thisViewModel.Edit = user.Edit;
                thisViewModel.Delete = user.Delete;
                userViewModel.Add(thisViewModel);
            }
            return View(userViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Manage(string userId)
        {
            UserViewModel model = new UserViewModel();
            PruebaTecnica_WebMasterUser user = await _userManager.FindByIdAsync(userId);
            ViewBag.UserName = user.UserName;
            ViewBag.Email = user.Email;
            if (user != null)
            {
                model.Create = user.Create;
                model.Edit = user.Edit;
                model.Delete = user.Delete;
                return View(model);
            }
            else
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Manage(UserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user != null)
            {
                user.Create = model.Create;
                user.Edit = model.Edit;
                user.Delete = model.Delete;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string UserId)
        {
            PruebaTecnica_WebMasterUser user = await _userManager.FindByIdAsync(UserId);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View();
        }

    }
}