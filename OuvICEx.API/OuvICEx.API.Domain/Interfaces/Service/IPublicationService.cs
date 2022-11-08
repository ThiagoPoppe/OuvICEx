using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Domain.Interfaces.Service
{
    public interface IPublicationService
    {
        public Publication? GetPublicationById(int id);
        public IEnumerable<Publication> GetAllPublications();

        public Publication CreatePublication(PublicationModel publicationModel);
    }
}
