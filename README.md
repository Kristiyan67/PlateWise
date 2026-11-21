# PlateWise

A recipe sharing and weekly meal planning web application built with ASP.NET Core (.NET 10).

## Concept

## Features

## Architecture

## Technologies

## Database Design

Entity | Description

ApplicationUser | ASP.NET Identity user with a display name
Category | Recipe category (unique name)
Ingredient | Ingredient with a default measurement unit (unique name)
Recipe | Recipe with author, category, difficulty, times and servings
RecipeIngredient | Many-to-many link between recipes and ingredients with quantity and unit
Review | Rating (1-5) and comment; one active review per user per recipe
Favorite | Saved recipe per user (composite key prevents duplicates)
MealPlan | A user's named plan starting on a given date
MealPlanEntry | Recipe assigned to a date, meal type and number of servings

*Design decisions:*
- All entities except the join table inherit from BaseEntity (Id, CreatedOn, IsDeleted).
- Recipes and ingredients use soft delete through EF Core global query filters.
- Foreign keys use Restrict delete behavior so that referenced data cannot be removed by accident.
- Validation limits live in ValidationConstants and are shared by the database configuration, view models and tests.
- Database check constraints enforce review ratings (1-5) and meal plan servings.
- A filtered unique index allows a user to review a recipe again after deleting an earlier review.
- The shopping list is not stored: it is generated from meal plan entries and recipe ingredients.

## Services

## Validation & Security

## Seeding

## Testing

## Setup Instructions

## Deployment