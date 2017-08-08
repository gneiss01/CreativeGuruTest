using System;
using System.Collections.Generic;

namespace TestWeb.Data.Model
{
    public class Product
    {
        public Guid Id { get; set; }

        public string DisplayName { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
