using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TestWeb.Data.Model;

namespace TestWeb.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("Name=StoreContext")
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
