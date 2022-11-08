using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Domain.Interfaces.Repository
{
    public interface IPublicationRepository
    {
        public Task<IEnumerable<Publication>> GetAllPublicationsAsync();
        public Task<Publication?> GetPublicationByIdAsync(int id);

        public Task<Publication> CreatePublicationAsync(Publication publication);
    }
}
