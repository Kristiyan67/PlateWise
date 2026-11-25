using PlateWise.Data;
using PlateWise.Services.Contracts;
using PlateWise.Services.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Services.Implementations
{
    public class IngredientService : IIngredientService
    {
        private readonly PlateWiseDbContext context;

        public IngredientService(PlateWiseDbContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<IngredientLookupModel>> GetAllAsync()
        {
            return await context.Ingredients
                .AsNoTracking()
                .OrderBy(i => i.Name)
                .Select(i => new IngredientLookupModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    DefaultUnit = i.DefaultUnit
                })
                .ToListAsync();
        }
    }
}
