using System;
using System.Collections.Generic;
using System.Text;
using PlateWise.Common.Enums;

namespace PlateWise.Services.Models.Recipes
{
    public class RecipeCardModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string AuthorName { get; set; } = string.Empty;

        public Difficulty Difficulty { get; set; }

        public int TotalTimeMinutes { get; set; }

        public double AverageRating { get; set; }

        public int ReviewsCount { get; set; }
    }
}
