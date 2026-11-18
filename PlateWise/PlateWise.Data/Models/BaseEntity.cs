using System;
using System.Collections.Generic;
using System.Text;

namespace PlateWise.Data.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; }
    }
}
