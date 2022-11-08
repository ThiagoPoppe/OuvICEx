using Microsoft.EntityFrameworkCore;
using OuvICEx.API.Repository.Data;
using OuvICEx.API.Domain.Interfaces.Repository;

namespace OuvICEx.API.Repository.Repository
{

    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected OuvICExDbContext _context;

        protected RepositoryBase(OuvICExDbContext context)
        {
            _context = context;
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void AddEntity(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public void UpdateEntity(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveEntity(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChanges();
        }

        public TEntity? FindByPrimaryKey(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAllEntities()
        {
            return _context.Set<TEntity>().AsEnumerable();
        }

        public IQueryable<TEntity> GetQuery(IEnumerable<string>? includes = null)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
    }
}