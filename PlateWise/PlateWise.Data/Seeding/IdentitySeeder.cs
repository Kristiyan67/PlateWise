using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using PlateWise.Common.Constants;
using PlateWise.Data.Models;

namespace PlateWise.Data.Seeding
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(
        RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager,
        string? adminEmail,
        string? adminPassword,
        string adminDisplayName)
        {
            await SeedRolesAsync(roleManager);

            if (string.IsNullOrWhiteSpace(adminEmail) || string.IsNullOrWhiteSpace(adminPassword))
            {
                return;
            }

            await SeedAdministratorAsync(userManager, adminEmail, adminPassword, adminDisplayName);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { RoleNames.Administrator, RoleNames.User };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var result = await roleManager.CreateAsync(new IdentityRole(role));
                    EnsureSucceeded(result, $"creating role '{role}'");
                }
            }
        }

        private static async Task SeedAdministratorAsync(
        UserManager<ApplicationUser> userManager,
        string email,
        string password,
        string displayName)
        {
            var admin = await userManager.FindByEmailAsync(email);

            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    DisplayName = displayName
                };

                var createResult = await userManager.CreateAsync(admin, password);
                EnsureSucceeded(createResult, "creating the administrator");
            }

            if (!await userManager.IsInRoleAsync(admin, RoleNames.Administrator))
            {
                var roleResult = await userManager.AddToRoleAsync(admin, RoleNames.Administrator);
                EnsureSucceeded(roleResult, "assigning the administrator role");
            }
        }

        private static void EnsureSucceeded(IdentityResult result, string action)
        {
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Seeding failed while {action}: {errors}");
            }
        }
    }
}
