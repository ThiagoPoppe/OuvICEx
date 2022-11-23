using Moq;
using Xunit;

using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Interfaces.Repository;
using OuvICEx.API.Domain.Services;

namespace OuvICEx.API.Tests.Unit
{
    public class PublicationServiceTest
    {
        #region Mock
        private readonly Publication DefaultPublication = new Publication();

        private Mock<IPublicationRepository> CreatePublicationRepositoryMock()
        {
            var publicationRepositoryMock = new Mock<IPublicationRepository>();

            publicationRepositoryMock.Setup(p => p.FindPublicationById(It.IsAny<int>())).Returns(DefaultPublication);

            return publicationRepositoryMock;
        }
        #endregion

        [Fact]
        public void MyTest()
        {
            var publicationRepositoryMock = CreatePublicationRepositoryMock();
            var publicationService = new PublicationService(publicationRepositoryMock.Object);

            var publication = publicationService.GetPublicationById(0);
            Assert.NotNull(publication);
        }
    }
}
