using PlateWise.Data;
using PlateWise.Services.Contracts;
using PlateWise.Services.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly PlateWiseDbContext context;

        public CategoryService(PlateWiseDbContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<LookupItemModel>> GetAllAsync()
        {
            return await context.Categories
                .AsNoTracking()
                .Where(c => !c.IsDeleted)
                .OrderBy(c => c.Name)
                .Select(c => new LookupItemModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }
    }
}
