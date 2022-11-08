using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Domain.Interfaces.Service
{
    public interface IPublicationService
    {
        public IEnumerable<Publication> GetAllPublications();
    }
}
