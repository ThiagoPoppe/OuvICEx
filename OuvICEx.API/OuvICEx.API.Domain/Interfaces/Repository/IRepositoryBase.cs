namespace OuvICEx.API.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        public void SaveChanges();
        public void AddEntity(TEntity obj);
        public void UpdateEntity(TEntity obj);
        public void RemoveEntity(TEntity obj);

        public TEntity? FindByPrimaryKey(int id);
        public IEnumerable<TEntity> GetAllEntities();
        public IQueryable<TEntity> GetQuery(IEnumerable<string>? includes = null);
    }
}