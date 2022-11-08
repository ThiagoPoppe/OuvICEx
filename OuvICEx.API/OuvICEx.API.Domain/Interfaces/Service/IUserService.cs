using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Domain.Interfaces.Service
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public void CreateUser(UserModel user);
    }
}
