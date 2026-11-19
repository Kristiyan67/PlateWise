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
    }
}
