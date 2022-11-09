using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Domain.Interfaces.Service
{
    public interface IPublicationService
    {
        public PublicationModel? GetPublicationById(int id);
        public IEnumerable<PublicationModel> GetAllPublications();
        public IEnumerable<PublicationModel> GetAllVisiblePublications();
        public IEnumerable<PublicationModel> GetPublicationsFromUser(int userId);

        public Publication CreatePublication(PublicationCreationModel publicationModel);
    }
}
