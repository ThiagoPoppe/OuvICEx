using Moq;
using Xunit;

using OuvICEx.API.Domain.Enums;
using OuvICEx.API.Domain.Models;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Services;
using OuvICEx.API.Domain.Interfaces.Repository;

namespace OuvICEx.API.Tests.Unit
{
    public class PublicationServiceTest
    {
        #region Mock
        private readonly Publication publication1 = new Publication
        {
            Id = 1,
            Title = "Publicação Teste 1",
            Text = "Texto Teste 1",
            Status = PublicationStatus.Unsolved,
            Context = PublicationContext.Complaint,
            PermissionToPublicate = false,
            CreatedAt = DateTime.Now,

            UserId = null,
            User = null,

            TargetDepartamentId = null,
            TargetDepartament = null
        };

        private readonly Publication publication2 = new Publication
        {
            Id = 2,
            Title = "Publicação Teste 2",
            Text = "Texto Teste 2",
            Status = PublicationStatus.Solved,
            Context = PublicationContext.Compliment,
            PermissionToPublicate = true,
            CreatedAt = DateTime.Now,

            UserId = 1,
            User = new User
            {
                Id = 1,
                Name = "Usuário Teste",
                Email = "usuario.teste@gmail.com",
                Password = "Senha@123",

                DepartamentId = 1,
                Departament = new Departament
                {
                    Id = 1,
                    Name = "DCC"
                }
            },

            TargetDepartamentId = null,
            TargetDepartament = null
        };

        private readonly Publication publication3 = new Publication
        {
            Id = 3,
            Title = "Publicação Teste 3",
            Text = "Texto Teste 3",
            Status = PublicationStatus.InProgress,
            Context = PublicationContext.Suggestion,
            PermissionToPublicate = true,
            CreatedAt = DateTime.Now,

            UserId = 1,
            User = new User
            {
                Id = 1,
                Name = "Usuário Teste",
                Email = "usuario.teste@gmail.com",
                Password = "Senha@123",

                DepartamentId = 1,
                Departament = new Departament
                {
                    Id = 1,
                    Name = "DCC"
                }
            },

            TargetDepartamentId = 1,
            TargetDepartament = new Departament
            {
                Id = 1,
                Name = "DCC"
            }
        };

        private IEnumerable<Publication> GetDefaultPublications()
        {
            return new List<Publication> { publication1, publication2, publication3 };
        }

        private IEnumerable<Publication> GetPublicationsFromUser()
        {
            return new List<Publication> { publication2, publication3 };
        }

        private Mock<IPublicationRepository> CreatePublicationRepositoryMock()
        {
            var publicationRepositoryMock = new Mock<IPublicationRepository>();

            publicationRepositoryMock.Setup(p => p.GetAllPublications()).Returns(GetDefaultPublications());
            
            publicationRepositoryMock.Setup(p => p.GetPublicationsFromUser(1)).Returns(GetPublicationsFromUser());
            publicationRepositoryMock.Setup(p => p.GetPublicationsFromUser(It.IsNotIn(1))).Returns(new List<Publication>());

            publicationRepositoryMock.Setup(p => p.FindPublicationById(1)).Returns(publication1);
            publicationRepositoryMock.Setup(p => p.FindPublicationById(2)).Returns(publication2);
            publicationRepositoryMock.Setup(p => p.FindPublicationById(3)).Returns(publication3);
            publicationRepositoryMock.Setup(p => p.FindPublicationById(It.IsNotIn(1, 2, 3))).Returns(null as Publication); 

            return publicationRepositoryMock;
        }
        #endregion

        [Fact]
        public void GetAllPublicationsTest()
        {
            var publicationRepositoryMock = CreatePublicationRepositoryMock();
            var publicationService = new PublicationService(publicationRepositoryMock.Object);

            var publications = publicationService.GetAllPublications();
            Assert.Equal(3, publications.Count());
        }

        [Fact]
        public void GetAllVisiblePublicationsTest()
        {
            var publicationRepositoryMock = CreatePublicationRepositoryMock();
            var publicationService = new PublicationService(publicationRepositoryMock.Object);

            var publications = publicationService.GetAllVisiblePublications();
            Assert.Equal(2, publications.Count());
        }

        [Fact]
        public void GetAllPublicationsFromExistingUserTest()
        {
            var publicationRepositoryMock = CreatePublicationRepositoryMock();
            var publicationService = new PublicationService(publicationRepositoryMock.Object);

            var publications = publicationService.GetPublicationsFromUser(1);
            Assert.Equal(2, publications.Count());
        }

        [Fact]
        public void GetAllPublicationsFromNonExistingUserTest()
        {
            var publicationRepositoryMock = CreatePublicationRepositoryMock();
            var publicationService = new PublicationService(publicationRepositoryMock.Object);

            var publications = publicationService.GetPublicationsFromUser(0);
            Assert.Empty(publications);
        }

        [Fact]
        public void FindPublicationByIdThatExistsTest()
        {
            var publicationRepositoryMock = CreatePublicationRepositoryMock();
            var publicationService = new PublicationService(publicationRepositoryMock.Object);

            var publication1 = publicationService.GetPublicationById(1);
            var publication2 = publicationService.GetPublicationById(2);
            var publication3 = publicationService.GetPublicationById(3);

            Assert.NotNull(publication1);
            Assert.NotNull(publication2);
            Assert.NotNull(publication3);
        }

        [Fact]
        public void FindPublicationByIdThatDoesNotExistsTest()
        {
            var publicationRepositoryMock = CreatePublicationRepositoryMock();
            var publicationService = new PublicationService(publicationRepositoryMock.Object);

            var publication1 = publicationService.GetPublicationById(0);
            var publication2 = publicationService.GetPublicationById(10);

            Assert.Null(publication1);
            Assert.Null(publication2);
        }

        [Fact]
        public void CreatePublicationTest()
        {
            var publicationRepositoryMock = CreatePublicationRepositoryMock();
            var publicationService = new PublicationService(publicationRepositoryMock.Object);

            var publication = publicationService.CreatePublication(new PublicationCreationModel());

            Assert.IsType<Publication>(publication);
        }
    }
}
