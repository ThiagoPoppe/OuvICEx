using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Domain.Interfaces.Service
{
    public interface IPublicationService
    {
        public Task<IEnumerable<Publication>> GetAllPublicationsAsync();
    }
}
