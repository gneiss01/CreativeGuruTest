using System.Collections.Generic;
using System.Data.Entity;
using TestWeb.Data.Model;
using System.Linq;

namespace TestWeb.Data.Repository
{
    public class ProductRepo : Repository<Product>
    {
        public ProductRepo(DbContext context) : base(context) { }

        public List<Product> GetAll(bool? isActive = null)
        {
            return base.GetAll()
                .Where(p => isActive == null || p.IsActive == isActive.Value)
                .Select(p => p).ToList();
        }
    }
}
