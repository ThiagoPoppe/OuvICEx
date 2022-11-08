using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Domain.Interfaces.Service
{
    public interface IPublicationService
    {
        public IEnumerable<Publication> GetAllPublications();
    }
}
