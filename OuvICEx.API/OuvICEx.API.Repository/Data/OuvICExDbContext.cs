using Microsoft.EntityFrameworkCore;
using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Repository.Data
{
    public class OuvICExDbContext : DbContext
    {
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<User> Users { get; set; }

        public OuvICExDbContext(DbContextOptions<OuvICExDbContext> options)
            : base(options) { }
    }
}
