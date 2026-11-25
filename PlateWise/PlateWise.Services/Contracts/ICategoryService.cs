using PlateWise.Services.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IReadOnlyList<LookupItemModel>> GetAllAsync();
    }
}
