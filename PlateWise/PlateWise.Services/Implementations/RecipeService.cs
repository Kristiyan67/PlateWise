using PlateWise.Data;
using PlateWise.Services.Contracts;
using PlateWise.Services.Models.Recipes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Services.Implementations
{
    public class RecipeService : IRecipeService
    {
        private readonly PlateWiseDbContext context;

        public RecipeService(PlateWiseDbContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<RecipeCardModel>> GetLatestAsync(int count)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(count, 1);

            return await context.Recipes
                .AsNoTracking()
                .OrderByDescending(r => r.CreatedOn)
                .ThenByDescending(r => r.Id)
                .Take(count)
                .Select(r => new RecipeCardModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                    CategoryName = r.Category.Name,
                    AuthorName = r.Author.DisplayName,
                    Difficulty = r.Difficulty,
                    TotalTimeMinutes = r.PreparationTimeMinutes + r.CookingTimeMinutes,
                    ReviewsCount = r.Reviews.Count,
                    AverageRating = r.Reviews.Count == 0 ? 0 : r.Reviews.Average(x => x.Rating)
                })
                .ToListAsync();
        }

        public async Task<RecipeDetailsModel?> GetDetailsAsync(int id)
        {
            return await context.Recipes
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(r => new RecipeDetailsModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    Instructions = r.Instructions,
                    PreparationTimeMinutes = r.PreparationTimeMinutes,
                    CookingTimeMinutes = r.CookingTimeMinutes,
                    Servings = r.Servings,
                    Difficulty = r.Difficulty,
                    ImageUrl = r.ImageUrl,
                    CategoryId = r.CategoryId,
                    CategoryName = r.Category.Name,
                    AuthorId = r.AuthorId,
                    AuthorName = r.Author.DisplayName,
                    CreatedOn = r.CreatedOn,
                    ReviewsCount = r.Reviews.Count,
                    AverageRating = r.Reviews.Count == 0 ? 0 : r.Reviews.Average(x => x.Rating),
                    Ingredients = r.RecipeIngredients
                        .OrderBy(ri => ri.Ingredient.Name)
                        .Select(ri => new RecipeIngredientModel
                        {
                            IngredientId = ri.IngredientId,
                            IngredientName = ri.Ingredient.Name,
                            Quantity = ri.Quantity,
                            Unit = ri.Unit
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}
