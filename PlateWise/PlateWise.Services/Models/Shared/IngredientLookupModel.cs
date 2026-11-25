using PlateWise.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Services.Models.Shared
{
    public class IngredientLookupModel : LookupItemModel
    {
        public MeasurementUnit DefaultUnit { get; set; }
    }
}
