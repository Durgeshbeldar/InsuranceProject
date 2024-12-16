using DsInsurance.Data;
using DsInsurance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Repositories.Implemetations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly InsuranceContext _context;
        private readonly DbSet<T> _table;

        public Repository(InsuranceContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public int Add(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T GetById(Guid id)
        {
            return _table.Find(id);
        }

        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _table.AddRange(entities);
            _context.SaveChanges();
        }
    }
}
