using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Domain.Interfaces.Service
{
    public interface IPublicationService
    {
        public PublicationModel? GetPublicationById(int id);
        public IEnumerable<PublicationModel> GetAllPublications();

        public Publication CreatePublication(PublicationCreationModel publicationModel);
    }
}
