using System.Collections.Generic;
using TestWeb.Data.Model;

namespace TestWeb.Data.Repository
{
    public interface IProductRepo : IRepository<Product>
    {
        List<Product> GetAll(bool? isActive = null);
    }
}
