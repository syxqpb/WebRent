using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Managers;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.DataAccessLayer.Models.Identity;

namespace WebTest2ebt.UI.AppConfiguration
{
    public class IdentityInitializer
    {
        private const string AdminEmail = "admin@gmail.com";
        private const string Password = "KOV1slv";

        public static async Task InitializeAsync(UserManager<IdentityBuyer> userManager, RoleManager<IdentityRole> roleManager/*, StorageManager storageManager*/)
        {
            if (await roleManager.FindByNameAsync(RolesNames.Admin) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(RolesNames.Admin));
            }

            if (await roleManager.FindByNameAsync(RolesNames.User) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(RolesNames.User));
            }

            if (await userManager.FindByNameAsync(AdminEmail) == null)
            {
                IdentityBuyer admin = new IdentityBuyer { Email = AdminEmail, UserName = AdminEmail};
                IdentityResult result = await userManager.CreateAsync(admin, Password);
                //Storage storage = new Storage { Id = 1, Name = "Склад" };
                //storageManager.Add(storage);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, RolesNames.Admin);
                }
            }
        }
    }
}
