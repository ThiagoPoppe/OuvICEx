using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Interfaces.Repository;
using OuvICEx.API.Repository.Data;

namespace OuvICEx.API.Repository.Repository
{
    public class DepartamentRepository : RepositoryBase<Departament>, IDepartamentRepository
    {
        public DepartamentRepository(OuvICExDbContext context)
            : base(context) { }
    }
}
