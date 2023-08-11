using Microsoft.EntityFrameworkCore;
using Staj.Interfaces;
using Staj.Models;

namespace Staj.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DoorContext _context;

        public Repository(DoorContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T entity = _context.Set<T>().Find(id);
            if (entity != null)
                _context.Set<T>().Remove(entity);
        }
    }

}
