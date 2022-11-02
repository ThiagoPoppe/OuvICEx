using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Domain.Interfaces.Repository
{
    public interface IPublicationRepository
    {
        public Task<IEnumerable<Publication>> GetAllPublicationsAsync();
    }
}
