using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Data.Models
{
    public class Favorite
    {
        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; } = null!;

        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
    }
}
