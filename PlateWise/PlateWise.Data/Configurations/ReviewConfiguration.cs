using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlateWise.Common.Constants;
using PlateWise.Data.Models;

namespace PlateWise.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(r => r.Comment)
                .IsRequired()
                .HasMaxLength(ValidationConstants.Review.CommentMaxLength);

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Reviews_Rating",
                $"[Rating] >= {ValidationConstants.Review.MinRating} AND [Rating] <= {ValidationConstants.Review.MaxRating}"));

            builder.HasOne(r => r.Recipe)
                .WithMany(rec => rec.Reviews)
                .HasForeignKey(r => r.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(r => new { r.RecipeId, r.UserId })
                .IsUnique()
                .HasFilter("[IsDeleted] = 0");

            builder.HasQueryFilter(r => !r.IsDeleted && !r.Recipe.IsDeleted);
        }
    }
}
