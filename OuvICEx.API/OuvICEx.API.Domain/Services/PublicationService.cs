using OuvICEx.API.Domain.Interfaces.Service;
using OuvICEx.API.Domain.Interfaces.Repository;
using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Domain.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _repository;

        public PublicationService(IPublicationRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Publication> GetAllPublications()
        {
            return _repository.GetAllEntities();
        }
    }
}
