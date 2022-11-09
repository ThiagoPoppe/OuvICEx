using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Domain.Interfaces.Service
{
    public interface IUserService
    {
        public IEnumerable<UserModel> GetAllUsers();
        public UserModel? GetUserByEmail(string email);
        public void CreateUser(UserCreationModel user);
    }
}
