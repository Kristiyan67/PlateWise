using PlateWise.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Data.Models
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public MeasurementUnit DefaultUnit { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new HashSet<RecipeIngredient>();
    }
}
