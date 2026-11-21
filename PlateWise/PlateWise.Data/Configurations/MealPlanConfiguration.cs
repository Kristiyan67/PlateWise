using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlateWise.Common.Constants;
using PlateWise.Data.Models;

namespace PlateWise.Data.Configurations
{
    public class MealPlanConfiguration : IEntityTypeConfiguration<MealPlan>
    {
        public void Configure(EntityTypeBuilder<MealPlan> builder)
        {
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(ValidationConstants.MealPlan.NameMaxLength);

            builder.HasOne(m => m.User)
                .WithMany(u => u.MealPlans)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(m => m.UserId);

            builder.HasQueryFilter(m => !m.IsDeleted);
        }
    }
}
