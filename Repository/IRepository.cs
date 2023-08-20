using System.Linq.Expressions;

namespace Server.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> Getall();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);

    }
}
