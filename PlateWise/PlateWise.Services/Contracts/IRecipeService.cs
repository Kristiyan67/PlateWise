using PlateWise.Services.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Services.Contracts
{
    public interface IRecipeService
    {
        Task<IReadOnlyList<RecipeCardModel>> GetLatestAsync(int count);

        Task<RecipeDetailsModel?> GetDetailsAsync(int id);
    }
}
