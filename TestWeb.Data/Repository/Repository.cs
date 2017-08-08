using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TestWeb.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext context = null;
        protected IDbSet<T> data = null;

        public Repository(DbContext context)
        {
            this.context = context;
            this.data = context.Set<T>();
        }

        public void Add(T entity)
        {
            this.data.Add(entity);
        }

        public void Delete(T entity)
        {
            this.data.Remove(entity);
        }

        public T FindByKey(params object[] keyValues)
        {
            return this.data.Find(keyValues);
        }

        public List<T> GetAll()
        {
            return this.data.ToList();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
