using System;
using System.Collections.Generic;

namespace TestWeb.Data.Model
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public Guid Id { get; set; }

        public string DisplayName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
