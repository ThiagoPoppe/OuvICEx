﻿using OuvICEx.API.Domain.Interfaces.Service;
using OuvICEx.API.Domain.Interfaces.Repository;
using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAllEntities();
        }
    }
}
