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

        public async Task<Publication?> GetPublicationByIdAsync(int id)
        {
            return await _context.Publications.FindAsync(id);
        }

        public async Task<Publication> CreatePublicationAsync(Publication publication)
        {
            await _context.Publications.AddAsync(publication);
            await _context.SaveChangesAsync();

            return publication;
        }
    }
}
