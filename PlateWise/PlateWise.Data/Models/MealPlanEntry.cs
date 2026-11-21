using System;
using System.Collections.Generic;
using System.Text;
using PlateWise.Common.Enums;

namespace PlateWise.Data.Models
{
    public class MealPlanEntry
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public MealType MealType { get; set; }

        public int Servings { get; set; }

        public int MealPlanId { get; set; }

        public MealPlan MealPlan { get; set; } = null!;

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; } = null!;
    }
}
