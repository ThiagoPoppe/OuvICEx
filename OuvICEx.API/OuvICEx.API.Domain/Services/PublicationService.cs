using OuvICEx.API.Domain.Interfaces.Service;
using OuvICEx.API.Domain.Interfaces.Repository;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

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

        public Publication? GetPublicationById(int id)
        {
            return _repository.FindByPrimaryKey(id);
        }

        public Publication CreatePublication(PublicationModel publicationModel)
        {
            Publication publication = new Publication
            {
                Title = publicationModel.Title,
                Text = publicationModel.Text,
                Status = publicationModel.Status,
                Context = publicationModel.Context,
                PermissionToPublicate = publicationModel.PermissionToPublicate,
                CreatedAt = DateTime.Now
            };

            _repository.AddEntity(publication);
            return publication;
        }
    }
}
