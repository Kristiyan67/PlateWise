using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PlateWise.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PlateWise.Data
{
    public class PlateWiseDbContext : IdentityDbContext<ApplicationUser>
    {
        public PlateWiseDbContext(DbContextOptions<PlateWiseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<Ingredient> Ingredients => Set<Ingredient>();

        public DbSet<Recipe> Recipes => Set<Recipe>();

        public DbSet<RecipeIngredient> RecipeIngredients => Set<RecipeIngredient>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(PlateWiseDbContext).Assembly);
        }
    }
}
