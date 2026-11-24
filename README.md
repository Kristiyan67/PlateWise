# PlateWise

A recipe sharing and weekly meal planning web application built with ASP.NET Core (.NET 10).

## Concept

## Features

## Architecture

Project | Responsibility

PlateWise.Common | Enums, role names and validation constants shared by all layers
PlateWise.Data | Entities, EF Core DbContext, Fluent API configurations, migrations, seeding
PlateWise.Services | Business logic behind interfaces, plus the models services return
PlateWise.Web | MVC controllers, Razor views, view models, Areas, SignalR hubs
PlateWise.Tests | Unit tests for the service layer

Dependencies point one way only: Web -> Services -> Data -> Common. Controllers stay thin and depend on service interfaces.

### UI structure

- _Layout defines the Styles and Scripts sections
- Partial views: _Navbar, _Footer, _LoginPartial, _Notifications, _RecipeCard, _Pagination
- Responsive Bootstrap 5 layout with a custom green theme in site.css

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

- Client-side validation (jQuery Validation), server-side validation (ModelState) and database constraints
- Global AutoValidateAntiforgeryToken filter protects all POST requests against CSRF
- Razor encodes all output by default, protecting against XSS
- Passwords are hashed by ASP.NET Identity; account lockout after repeated failed logins
- Login errors are generic, so registered emails can't be discovered
- returnUrl is checked with Url.IsLocalUrl, preventing open redirects

## Seeding

On startup the application applies pending migrations and seeds:

- the roles Administrator and User
- a demo administrator account, read from the Seed section of configuration

Demo administrator (development only):

Email | Password
admin@platewise.com | Admin12345

In production these values are supplied through environment variables, never from source control.

## Testing

## Setup Instructions

## Deployment