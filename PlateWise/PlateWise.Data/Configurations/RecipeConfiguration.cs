using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlateWise.Common.Constants;
using PlateWise.Data.Models;

namespace PlateWise.Data.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(r => r.Title)
            .IsRequired()
            .HasMaxLength(ValidationConstants.Recipe.TitleMaxLength);

            builder.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(ValidationConstants.Recipe.DescriptionMaxLength);

            builder.Property(r => r.Instructions)
                .IsRequired()
                .HasMaxLength(ValidationConstants.Recipe.InstructionsMaxLength);

            builder.Property(r => r.ImageUrl)
                .HasMaxLength(ValidationConstants.Recipe.ImageUrlMaxLength);

            builder.HasOne(r => r.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Author)
                .WithMany(u => u.Recipes)
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(r => r.Title);

            builder.HasQueryFilter(r => !r.IsDeleted);
        }
    }
}
