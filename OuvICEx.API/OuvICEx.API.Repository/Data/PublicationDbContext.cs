using Microsoft.EntityFrameworkCore;
using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Repository.Data
{
    public class PublicationDbContext : DbContext
    {
        public DbSet<Publication> Publications { get; set; }

        public PublicationDbContext(DbContextOptions<PublicationDbContext> options)
            : base(options) { }
    }
}
