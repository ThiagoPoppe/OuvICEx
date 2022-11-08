using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Domain.Interfaces.Service
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
    }
}
