using PlateWise.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Services.Models.Recipes
{
    public class RecipeDetailsModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Instructions { get; set; } = string.Empty;

        public int PreparationTimeMinutes { get; set; }

        public int CookingTimeMinutes { get; set; }

        public int Servings { get; set; }

        public Difficulty Difficulty { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string AuthorId { get; set; } = string.Empty;

        public string AuthorName { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public double AverageRating { get; set; }

        public int ReviewsCount { get; set; }

        public List<RecipeIngredientModel> Ingredients { get; set; } = new();
    }

    public class RecipeIngredientModel
    {
        public int IngredientId { get; set; }

        public string IngredientName { get; set; } = string.Empty;

        public decimal Quantity { get; set; }

        public MeasurementUnit Unit { get; set; }
    }
}
