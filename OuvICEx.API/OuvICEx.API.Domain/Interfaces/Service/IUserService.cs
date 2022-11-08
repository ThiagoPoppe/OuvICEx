using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Domain.Interfaces.Service
{
    public interface IUserService
    {
        public IEnumerable<UserModel> GetAllUsers();
        public void CreateUser(UserCreationModel user);
    }
}
