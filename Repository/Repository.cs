using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using System.Linq.Expressions;

namespace Server.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> entities;
        public Repository(DatabaseContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public T Add(T entity)
        {
            entities.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
            _context.SaveChanges();

        }

        public List<T> Getall()
        {
            return entities.ToList();

        }

        public T GetById(int id)
        {
            return entities.Find(id);
        }

        public T Update(T entity)
        {
            entities.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
