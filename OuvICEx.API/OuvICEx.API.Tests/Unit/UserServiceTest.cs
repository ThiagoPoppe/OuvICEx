using Moq;
using Xunit;

using OuvICEx.API.Domain.Enums;
using OuvICEx.API.Domain.Models;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Services;
using OuvICEx.API.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Http;

namespace OuvICEx.API.Tests.Unit
{
    public class UserServiceTest
    {
        #region Mock
        private readonly User User1 = new()
        {
            Id = 1,
            Name = "User 1",
            Email = "user1@email.com",
            Password = "Pass1",
            
        };

        private readonly User User2 = new()
        {
            Id = 2,
            Name = "User 2",
            Email = "user2@email.com",
            Password = "Pass2",

        };

        private readonly User User3 = new()
        {
            Id = 3,
            Name = "User 3",
            Email = "user3@email.com",
            Password = "Pass3",

        };

        private readonly UserCreationModel NewUserWithNewData = new()
        {
            Name = "User 4",
            Email = "user4@email.com",
            Password = "Pass4",
            DepartamentId = 1,
        };

        private readonly UserCreationModel NewUserWithMinimumLenghtPassword = new()
        {
            Name = "User 5",
            Email = "user5@email.com",
            Password = "Pas5",
            DepartamentId = 1,
        };

        private readonly UserCreationModel NewUserWithMaximumLenghtPassword = new()
        {
            Name = "User 5",
            Email = "user5@email.com",
            Password = "Passwor5",
            DepartamentId = 1,
        };

        private readonly UserCreationModel NewUserWithUsedEmail = new()
        {
            Name = "User 5",
            Email = "user3@email.com",
            Password = "Pass5",
            DepartamentId = 1,
        };

        private readonly UserCreationModel NewUserWithWrongEmailFormat = new()
        {
            Name = "User 5",
            Email = "user5@email",
            Password = "Pass5",
            DepartamentId = 1,
        };

        private readonly UserCreationModel NewUserWithSmallPassword = new()
        {
            Name = "User 5",
            Email = "user5@email.com",
            Password = "Pa5",
            DepartamentId = 1,
        };

        private readonly UserCreationModel NewUserWithBigPassword = new()
        {
            Name = "User 5",
            Email = "user5@email.com",
            Password = "Password5",
            DepartamentId = 1,
        };

        private readonly UserCreationModel NewUserWithPasswordWithoutNumber = new()
        {
            Name = "User 5",
            Email = "user5@email.com",
            Password = "Passwor",
            DepartamentId = 1,
        };

        private readonly UserCreationModel NewUserWithPasswordWithoutUperCase = new()
        {
            Name = "User 5",
            Email = "user5@email.com",
            Password = "passwor5",
            DepartamentId = 1,
        };

        private readonly UserCreationModel NewUserWithPasswordWithoutLowerCase = new()
        {
            Name = "User 5",
            Email = "user5@email.com",
            Password = "PASSWOR5",
            DepartamentId = 1,
        };


        private IEnumerable<User> GetDefaultUsers()
        {
            return new List<User> { User1, User2, User3 };
        }

        private IEnumerable<User> GetUsersFromUser()
        {
            return new List<User> { User2, User3 };
        }

        private Mock<IUserRepository> CreateUserRepositoryMock()
        {
            var UserRepositoryMock = new Mock<IUserRepository>();

            UserRepositoryMock.Setup(p => p.GetAllUsers()).Returns(GetDefaultUsers());

            UserRepositoryMock.Setup(p => p.GetUserByEmail(It.IsAny<string>())).Returns(null as User);
            UserRepositoryMock.Setup(p => p.GetUserByEmail("user1@email.com")).Returns(User1);
            UserRepositoryMock.Setup(p => p.GetUserByEmail("user2@email.com")).Returns(User2);
            UserRepositoryMock.Setup(p => p.GetUserByEmail("user3@email.com")).Returns(User3);

            return UserRepositoryMock;
        }
        #endregion

        [Fact]
        public void GetAllUsersTest()
        {
            var UserRepositoryMock = CreateUserRepositoryMock();
            var UserService = new UserService(UserRepositoryMock.Object);

            var Users = UserService.GetAllUsers();
            Assert.Equal(3, Users.Count());
        }

        [Fact]
        public void FindUserByEmailThatExistsTest()
        {
            var UserRepositoryMock = CreateUserRepositoryMock();
            var UserService = new UserService(UserRepositoryMock.Object);

            var User1 = UserService.GetUserByEmail("user1@email.com");
            var User2 = UserService.GetUserByEmail("user2@email.com");
            var User3 = UserService.GetUserByEmail("user3@email.com");

            Assert.NotNull(User1);
            Assert.NotNull(User2);
            Assert.NotNull(User3);
        }

        [Fact]
        public void FindUserByEmailThatDoesNotExistsTest()
        {
            var UserRepositoryMock = CreateUserRepositoryMock();
            var UserService = new UserService(UserRepositoryMock.Object);

            var User1 = UserService.GetUserByEmail("user4@email.com");
            var User2 = UserService.GetUserByEmail("user5@email.com");

            Assert.Null(User1);
            Assert.Null(User2);
        }

        [Fact]
        public void CreateValidUserTest()
        {
            var UserRepositoryMock = CreateUserRepositoryMock();
            var UserService = new UserService(UserRepositoryMock.Object);

            var exception = Record.Exception(() => UserService.CreateUser(NewUserWithNewData));
            Assert.Null(exception);
        }

        [Fact]
        public void CreateValidUserWithMinimumLenghPasswordTest()
        {
            var UserRepositoryMock = CreateUserRepositoryMock();
            var UserService = new UserService(UserRepositoryMock.Object);

            var exception = Record.Exception(() => UserService.CreateUser(NewUserWithMinimumLenghtPassword));
            Assert.Null(exception);
        }


        [Fact]
        public void CreateValidUserWithMaximumLenghPasswordTest()
        {
            var UserRepositoryMock = CreateUserRepositoryMock();
            var UserService = new UserService(UserRepositoryMock.Object);

            var exception = Record.Exception(() => UserService.CreateUser(NewUserWithMaximumLenghtPassword));
            Assert.Null(exception);
        }

        [Fact]
        public void CreateInvalidUserWithExistingEmailTest()
        {
            var UserRepositoryMock = CreateUserRepositoryMock();
            var UserService = new UserService(UserRepositoryMock.Object);

            Assert.Throws<BadHttpRequestException> (() => UserService.CreateUser(NewUserWithUsedEmail));
        }

        [Fact]
        public void CreateInvalidUserWithWrongEmailFormatTest()
        {
            var UserRepositoryMock = CreateUserRepositoryMock();
            var UserService = new UserService(UserRepositoryMock.Object);

            Assert.Throws<BadHttpRequestException>(() => UserService.CreateUser(NewUserWithWrongEmailFormat));
        }

        [Fact]
        public void CreateInvalidUserWithSmallPasswordTest()
        {
            var UserRepositoryMock = CreateUserRepositoryMock();
            var UserService = new UserService(UserRepositoryMock.Object);

            Assert.Throws<BadHttpRequestException>(() => UserService.CreateUser(NewUserWithSmallPassword));
        }

        [Fact]
        public void CreateInvalidUserWithBigPasswordTest()
        {
            var UserRepositoryMock = CreateUserRepositoryMock();
            var UserService = new UserService(UserRepositoryMock.Object);

            Assert.Throws<BadHttpRequestException>(() => UserService.CreateUser(NewUserWithBigPassword));
        }

        [Fact]
        public void CreateInvalidUserWithPasswordWithoutNumberTest()
        {
            var UserRepositoryMock = CreateUserRepositoryMock();
            var UserService = new UserService(UserRepositoryMock.Object);

            Assert.Throws<BadHttpRequestException>(() => UserService.CreateUser(NewUserWithPasswordWithoutNumber));
        }

        [Fact]
        public void CreateInvalidUserWithPasswordWithoutUperCase()
        {
            var UserRepositoryMock = CreateUserRepositoryMock();
            var UserService = new UserService(UserRepositoryMock.Object);

            Assert.Throws<BadHttpRequestException>(() => UserService.CreateUser(NewUserWithPasswordWithoutUperCase));
        }

        [Fact]
        public void CreateInvalidUserWithPasswordWithoutLowerCase()
        {
            var UserRepositoryMock = CreateUserRepositoryMock();
            var UserService = new UserService(UserRepositoryMock.Object);

            Assert.Throws<BadHttpRequestException>(() => UserService.CreateUser(NewUserWithPasswordWithoutLowerCase));
        }

        
    }
}
