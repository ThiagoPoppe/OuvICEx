using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Interfaces.Repository;
using OuvICEx.API.Repository.Data;

namespace OuvICEx.API.Repository.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly List<string> foreignObjectNames;

        public UserRepository(OuvICExDbContext context)
            : base(context) 
        {
            foreignObjectNames = new List<string> { "Departament" };
        }

        public IEnumerable<User> GetAllUsers()
        {
            return GetQuery().AsEnumerable();
        }

        public User? GetUserByEmail(string email)
        {
            return GetQuery().FirstOrDefault(x => x.Email == email);
        }
    }
}
