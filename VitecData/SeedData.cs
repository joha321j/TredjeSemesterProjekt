using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VitecData.Models;

namespace VitecData
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, VitecContext context)
        {
            var roleName = "admin";
            var pass = "!QAZ1qaz";

            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (!context.Users.Any())
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }

                var userManager = serviceProvider.GetService<UserManager<WebUser>>();

                var user = new WebUser
                {
                    UserName = "admin@admin.admin",
                    EmailConfirmed = true,
                    FirstName = "admin"
                };

                await userManager.CreateAsync(user, pass);
                await userManager.AddToRoleAsync(user, roleName);
            }

            context.SaveChanges();
        }
    }
}
