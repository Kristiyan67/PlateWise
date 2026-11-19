using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Common.Constants
{
    public static class ValidationConstants
    {
        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int DescriptionMinLength = 300;
        }

        public static class Ingredient
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 80;
        }

        public static class Recipe
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 100;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 500;

            public const int InstructionsMinLength = 20;
            public const int InstructionsMaxLength = 5000;

            public const int ImageUrlMaxLength = 2048;

            public const int MinServings = 1;
            public const int MaxServings = 50;

            public const int MinMinutes = 0;
            public const int MaxMinutes = 1440;
        }

        public static class RecipeIngredient
        {
            public const double MinQuantity = 0.01;
            public const double MaxQuantity = 100000;
        }
    }
}
