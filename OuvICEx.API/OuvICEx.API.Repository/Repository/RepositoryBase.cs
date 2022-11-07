using Microsoft.EntityFrameworkCore;
using OuvICEx.API.Repository.Data;
using OuvICEx.API.Domain.Interfaces.Repository;

namespace OuvICEx.API.Repository.Repository
{

    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected OuvICExDbContext Db;

        protected RepositoryBase(OuvICExDbContext db)
        {
            Db = db;
        }

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Attach(TEntity obj)
        {
            Db.Attach<TEntity>(obj);
        }

        public void AddWithoutSave(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public IQueryable<TEntity> GetQuery(IEnumerable<string> includes = null)
        {
            var query = Db.Set<TEntity>().AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().AsEnumerable();
        }

        public TEntity FindByPrimaryKey(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }
        public void DetachAllEntities()
        {
            var changedEntriesCopy = Db.ChangeTracker.Entries().ToList();
            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}