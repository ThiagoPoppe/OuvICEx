using OuvICEx.API.Domain.Interfaces.Service;
using OuvICEx.API.Domain.Interfaces.Repository;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;
using AutoMapper;
using OuvICEx.API.Domain.Profiles;

namespace OuvICEx.API.Domain.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IMapper _mapper;
        private readonly IPublicationRepository _repository;

        public PublicationService(IPublicationRepository repository)
        {
            _repository = repository;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PublicationProfile>();
            });
            _mapper = configuration.CreateMapper();
        }

        public IEnumerable<PublicationModel> GetAllPublications()
        {
            var publications = _repository.GetAllEntities();
            return _mapper.Map<IEnumerable<PublicationModel>>(publications);
        }

        public IEnumerable<PublicationModel> GetAllVisiblePublications()
        {
            var publications = _repository.GetAllEntities();

            List<PublicationModel> models = new List<PublicationModel>();
            foreach (var publication in publications)
                if (publication.PermissionToPublicate == true)
                    models.Add(_mapper.Map<PublicationModel>(publication));

            return models.AsEnumerable();
        }

        public PublicationModel? GetPublicationById(int id)
        {
            var publication = _repository.FindByPrimaryKey(id);
            return publication == null ? null : _mapper.Map<PublicationModel>(publication);
        }

        public Publication CreatePublication(PublicationCreationModel publicationCreationModel)
        {
            var publication = _mapper.Map<Publication>(publicationCreationModel);

            _repository.AddEntity(publication);
            return publication;
        }
    }
}
