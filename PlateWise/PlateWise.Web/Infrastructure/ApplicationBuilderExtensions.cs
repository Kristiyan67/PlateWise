using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlateWise.Data;
using PlateWise.Data.Models;
using PlateWise.Data.Seeding;

namespace PlateWise.Web.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task MigrateAndSeedAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<PlateWiseDbContext>();
            await context.Database.MigrateAsync();

            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            await IdentitySeeder.SeedAsync(
                roleManager,
                userManager,
                app.Configuration["Seed:AdminEmail"],
                app.Configuration["Seed:AdminPassword"],
                app.Configuration["Seed:AdminDisplayName"] ?? "Administrator");
        }
    }
}
