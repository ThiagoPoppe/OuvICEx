using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Domain.Interfaces.Service
{
    public interface IPublicationService
    {
        public Task<IEnumerable<Publication>> GetAllPublicationsAsync();
        public Task<Publication?> GetPublicationByIdAsync(int id);

        public Task<Publication> CreatePublicationAsync(PublicationModel publicationModel);
    }
}
