using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlateWise.Common.Constants;
using PlateWise.Data.Models;

namespace PlateWise.Data.Configurations
{
    public class MealPlanEntryConfiguration : IEntityTypeConfiguration<MealPlanEntry>
    {
        public void Configure(EntityTypeBuilder<MealPlanEntry> builder)
        {
            builder.ToTable(t => t.HasCheckConstraint(
                "CK_MealPlanEntries_Servings",
                $"[Servings] >= {ValidationConstants.MealPlanEntry.MinServings} AND [Servings] <= {ValidationConstants.MealPlanEntry.MaxServings}"));

            builder.HasOne(e => e.MealPlan)
                .WithMany(m => m.Entries)
                .HasForeignKey(e => e.MealPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Recipe)
                .WithMany()
                .HasForeignKey(e => e.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => new { e.MealPlanId, e.Date });

            builder.HasQueryFilter(e => !e.MealPlan.IsDeleted && !e.Recipe.IsDeleted);
        }
    }
}
