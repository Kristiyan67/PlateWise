using PlateWise.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Data.Models
{
    public class Recipe : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Instructions { get; set; } = string.Empty;

        public int PreparationTimeMinutes { get; set; }

        public int CookingTimeMinutes { get; set; }

        public int Servings { get; set; }

        public Difficulty Difficulty { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public string AuthorId { get; set; } = string.Empty;

        public ApplicationUser Author { get; set; } = null!;

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new HashSet<RecipeIngredient>();
    }
}
