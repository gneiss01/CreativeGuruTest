using System.Collections.Generic;

namespace TestWeb.Data.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void Delete(T entity);

        T FindByKey(params object[] keyValues);

        List<T> GetAll();

        void Save();
    }
}
