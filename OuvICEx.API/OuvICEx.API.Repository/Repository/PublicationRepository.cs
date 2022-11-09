using Microsoft.EntityFrameworkCore;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Interfaces.Repository;
using OuvICEx.API.Repository.Data;

namespace OuvICEx.API.Repository.Repository
{
    public class PublicationRepository : RepositoryBase<Publication>, IPublicationRepository
    {
        private readonly List<string> foreignObjectNames;

        public PublicationRepository(OuvICExDbContext context)
            : base(context)
        {
            foreignObjectNames = new List<string> { "User", "User.Departament", "TargetDepartament" };
        }

        public Publication? FindPublicationById(int id)
        {
            return GetQuery(foreignObjectNames)
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
        }

        public IEnumerable<Publication> GetAllPublications()
        {
            return GetQuery(foreignObjectNames)
                    .AsEnumerable();
        }
    }
}
