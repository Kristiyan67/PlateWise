# PlateWise

A recipe sharing and weekly meal planning web application built with ASP.NET Core (.NET 10).

## Concept

## Features

## Architecture

## Technologies

## Database Design

Entity : Description

ApplicationUser | ASP.NET Identity user with a display name
Category | Recipe category (unique name)
Ingredient | Ingredient with a default measurement unit (unique name)
Recipe | Recipe with author, category, difficulty, times and servings
RecipeIngredient | Many-to-many link between recipes and ingredients with quantity and unit

*Design decisions:*
- All entities except the join table inherit from BaseEntity (Id, CreatedOn, IsDeleted).
- Recipes and ingredients use soft delete through EF Core global query filters.
- Foreign keys use Restrict delete behavior so that referenced data cannot be removed by accident.
- Validation limits live in ValidationConstants and are shared by the database configuration, view models and tests.

## Services

## Validation & Security

## Seeding

## Testing

## Setup Instructions

## Deployment