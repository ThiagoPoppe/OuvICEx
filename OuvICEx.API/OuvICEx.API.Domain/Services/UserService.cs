using OuvICEx.API.Domain.Interfaces.Service;
using OuvICEx.API.Domain.Interfaces.Repository;
using OuvICEx.API.Domain.Entities;
using System.Text.RegularExpressions;
using OuvICEx.API.Domain.Models;
using AutoMapper;
using OuvICEx.API.Domain.Profiles;
using System.Reflection;

namespace OuvICEx.API.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        protected readonly IMapper _mapper;

        public UserService(IUserRepository repository)
        {
            _repository = repository;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });
            _mapper = configuration.CreateMapper();
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            var users = _repository.GetAllUsers();
            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        public UserModel? GetUserByEmail(string email)
        {
            var user = _repository.GetUserByEmail(email);
            return _mapper.Map<UserModel>(user);
        }

        public void CreateUser(UserCreationModel user)
        {
            ValidateEmail(user.Email);
            ValidatePassword(user.Password);
            
            _repository.AddEntity(_mapper.Map<User>(user));
        }

        private void ValidateEmail(string email)
        {
            if (!Regex.IsMatch(email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
            {
                throw new BadHttpRequestException("Email format invalid");
            }
            if(_repository.GetUserByEmail(email) != null)
            {
                throw new BadHttpRequestException("User already exists.");
            }
        }

        private static void ValidatePassword(string password)
        {
            if (!Regex.IsMatch(password, "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$"))
            {
                throw new BadHttpRequestException("Password must be at least 4 characters, no more than 8 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit.");
            }
        }
    }
}
