using Microsoft.EntityFrameworkCore;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Interfaces.Repository;
using OuvICEx.API.Repository.Data;

namespace OuvICEx.API.Repository.Repository
{
    public class PublicationRepository : IPublicationRepository
    {
        private readonly PublicationDbContext _context;

        public PublicationRepository(PublicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publication>> GetAllPublicationsAsync()
        {
            return await _context.Publications.ToListAsync();
        }
    }
}
