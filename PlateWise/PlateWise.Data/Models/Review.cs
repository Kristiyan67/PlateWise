using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Data.Models
{
    public class Review : BaseEntity
    {
        public int Rating { get; set; }

        public string Comment { get; set; } = string.Empty;

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; } = null!;

        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;
    }
}
