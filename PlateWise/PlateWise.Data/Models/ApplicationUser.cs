using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();
        public ICollection<MealPlan> MealPlans { get; set; } = new HashSet<MealPlan>();
    }
}
