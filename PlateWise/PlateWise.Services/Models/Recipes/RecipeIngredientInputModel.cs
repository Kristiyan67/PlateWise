using PlateWise.Common.Constants;
using PlateWise.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlateWise.Services.Models.Recipes
{
    public class RecipeIngredientInputModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please select an ingredient.")]
        public int IngredientId { get; set; }

        [Range(
            ValidationConstants.RecipeIngredient.MinQuantity,
            ValidationConstants.RecipeIngredient.MaxQuantity,
            ErrorMessage = "Quantity must be between {1} and {2}.")]
        public decimal Quantity { get; set; }

        [EnumDataType(typeof(MeasurementUnit))]
        public MeasurementUnit Unit { get; set; }
    }
}
