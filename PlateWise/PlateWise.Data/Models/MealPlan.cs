using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Data.Models
{
    public class MealPlan : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public DateOnly StartDate { get; set; }

        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;

        public ICollection<MealPlanEntry> Entries { get; set; } = new HashSet<MealPlanEntry>();
    }
}
