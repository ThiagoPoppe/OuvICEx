using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
