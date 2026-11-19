using PlateWise.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Data.Models
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; } = null!;

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; } = null!;

        public decimal Quantity { get; set; }

        public MeasurementUnit Unit { get; set; }
    }
}
