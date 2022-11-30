using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Domain.Interfaces.Repository
{
    public interface IPublicationRepository : IRepositoryBase<Publication>
    {
        public void RemovePublication(Publication publication);
        public Publication? FindPublicationById(int id);
        public IEnumerable<Publication> GetAllPublications();
        public IEnumerable<Publication> GetPublicationsFromUser(int userId);
    }
}
