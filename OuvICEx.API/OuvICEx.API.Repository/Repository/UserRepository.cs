using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Interfaces.Repository;
using OuvICEx.API.Repository.Data;

namespace OuvICEx.API.Repository.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(OuvICExDbContext context)
            : base(context) { }
    }
}
