using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_WebMaster.Areas.Identity.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<PruebaTecnica_WebMasterUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Administrador.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Normal.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<PruebaTecnica_WebMasterUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new PruebaTecnica_WebMasterUser
            {
                UserName = "FrancoGhost",
                Email = "francoGhost@gmail.com",
                FirstName = "FrancoGhost",
                LastName = "FrancoGhost",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Administrador.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Normal.ToString());
                }

            }
        }
    }
}
