using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Data.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();
    }
}
