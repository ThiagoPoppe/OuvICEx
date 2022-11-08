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

        private string? GetUserDepartamentName(Publication publication)
        {
            if (publication.User == null || publication.User.Departament == null)
                return null;

            return publication.User.Departament.Name;
        }

        private string? GetTargetDepartamentName(Publication publication)
        {
            return publication.TargetDepartament == null ? null : publication.TargetDepartament.Name;
        }

        private PublicationModel ConvertPublicationToPublicationModel(Publication publication)
        {
            return new PublicationModel
            {
                Text = publication.Text,
                Title = publication.Title,
                Status = publication.Status,
                Context = publication.Context,
                CreatedAt = publication.CreatedAt,
                AuthorDepartamentName = GetUserDepartamentName(publication),
                TargetDepartamentName = GetTargetDepartamentName(publication)
            };
        }

        public IEnumerable<PublicationModel> GetAllPublications()
        {
            var publications = _repository.GetAllEntities();

            List<PublicationModel> models = new List<PublicationModel>();
            foreach (var publication in publications)
                models.Add(ConvertPublicationToPublicationModel(publication));

            return models.AsEnumerable();
        }

        public PublicationModel? GetPublicationById(int id)
        {
            var publication = _repository.FindByPrimaryKey(id);
            return publication == null ? null : ConvertPublicationToPublicationModel(publication);
        }

        public Publication CreatePublication(PublicationCreationModel publicationCreationModel)
        {
            Publication publication = new Publication
            {
                Text = publicationCreationModel.Text,
                Title = publicationCreationModel.Title,
                Status = publicationCreationModel.Status,
                Context = publicationCreationModel.Context,
                PermissionToPublicate = publicationCreationModel.PermissionToPublicate,
                CreatedAt = DateTime.Now,
                UserId = publicationCreationModel.UserId,
                TargetDepartamentId = publicationCreationModel.TargetDepartamentId
            };

            _repository.AddEntity(publication);
            return publication;
        }
    }
}
