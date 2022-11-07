using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Domain.Interfaces.Repository
{
    public interface IPublicationRepository : IRepositoryBase<Publication>
    {
        public Task<IEnumerable<Publication>> GetAllPublicationsAsync();
    }
}
