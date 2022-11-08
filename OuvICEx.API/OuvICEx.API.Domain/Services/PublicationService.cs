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

        public async Task<IEnumerable<Publication>> GetAllPublicationsAsync()
        {
            return  await _repository.GetAllPublicationsAsync();
        }

        public async Task<Publication?> GetPublicationByIdAsync(int id)
        {
            return await _repository.GetPublicationByIdAsync(id);
        }

        public async Task<Publication> CreatePublicationAsync(PublicationModel publicationModel)
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

            return await _repository.CreatePublicationAsync(publication);
        }
    }
}
