using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlateWise.Common.Constants;
using PlateWise.Data.Models;

namespace PlateWise.Data.Configurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(ValidationConstants.Ingredient.NameMaxLength);

            builder.HasIndex(i => i.Name)
                .IsUnique();

            builder.HasQueryFilter(i => !i.IsDeleted);
        }
    }
}
