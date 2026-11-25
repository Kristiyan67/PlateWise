using PlateWise.Common.Constants;
using PlateWise.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlateWise.Services.Models.Recipes
{
    public class RecipeFormModel
    {
        [Required]
        [StringLength(
            ValidationConstants.Recipe.TitleMaxLength,
            MinimumLength = ValidationConstants.Recipe.TitleMinLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(
            ValidationConstants.Recipe.DescriptionMaxLength,
            MinimumLength = ValidationConstants.Recipe.DescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(
            ValidationConstants.Recipe.InstructionsMaxLength,
            MinimumLength = ValidationConstants.Recipe.InstructionsMinLength)]
        public string Instructions { get; set; } = string.Empty;

        [Range(ValidationConstants.Recipe.MinMinutes, ValidationConstants.Recipe.MaxMinutes)]
        [Display(Name = "Preparation time (minutes)")]
        public int PreparationTimeMinutes { get; set; }

        [Range(ValidationConstants.Recipe.MinMinutes, ValidationConstants.Recipe.MaxMinutes)]
        [Display(Name = "Cooking time (minutes)")]
        public int CookingTimeMinutes { get; set; }

        [Range(ValidationConstants.Recipe.MinServings, ValidationConstants.Recipe.MaxServings)]
        public int Servings { get; set; } = 4;

        [EnumDataType(typeof(Difficulty))]
        public Difficulty Difficulty { get; set; }

        [Url]
        [StringLength(ValidationConstants.Recipe.ImageUrlMaxLength)]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public List<RecipeIngredientInputModel> Ingredients { get; set; } = new();
    }
}
