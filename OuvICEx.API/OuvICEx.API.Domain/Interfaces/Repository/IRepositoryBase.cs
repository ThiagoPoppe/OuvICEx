using System.Collections.Generic;
using System.Linq;

namespace OuvICEx.API.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void AddWithoutSave(TEntity obj);
        void Dispose();
        void SaveChanges();

        TEntity FindByPrimaryKey(int id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetQuery(IEnumerable<string> includes = null);

        public void Attach(TEntity obj);
    }
}