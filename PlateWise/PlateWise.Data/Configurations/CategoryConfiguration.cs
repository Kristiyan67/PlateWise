using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlateWise.Common.Constants;
using PlateWise.Data.Models;

namespace PlateWise.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(ValidationConstants.Category.NameMaxLength);

            builder.Property(c => c.Description)
                .HasMaxLength(ValidationConstants.Category.DescriptionMaxLength);

            builder.HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}
