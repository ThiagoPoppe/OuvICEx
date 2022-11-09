using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public IEnumerable<User> GetAllUsers();
        public User? GetUserByEmail(string email);
    }
}
