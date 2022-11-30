using Microsoft.AspNetCore.Http;
using Moq;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Enums;
using OuvICEx.API.Domain.Exceptions;
using OuvICEx.API.Domain.Interfaces.Repository;
using OuvICEx.API.Domain.Models;
using OuvICEx.API.Domain.Services;
using System.Runtime.InteropServices;
using Xunit;

namespace OuvICEx.API.Tests.Unit
{ 
    public class DepartamentServiceTest
    {
        #region Mock
        private readonly Departament departamentDCC = new Departament
        {
            Id = 1,
            Name = "DCC"
        };

        private readonly Departament departamentDMAT = new Departament
        {
            Id = 2,
            Name = "DMAT"
        };

        private IEnumerable<Departament> GetDefaultDepartaments()
        {
            return new List<Departament> { departamentDCC, departamentDMAT };
        }

        private Mock<IDepartamentRepository> CreateDepartamentRepositoryMock()
        {
            var departamentRepositoryMock = new Mock<IDepartamentRepository>();

            departamentRepositoryMock.Setup(p => p.GetAllEntities()).Returns(GetDefaultDepartaments());

            departamentRepositoryMock.Setup(p => p.FindByPrimaryKey(1)).Returns(departamentDCC);
            departamentRepositoryMock.Setup(p => p.FindByPrimaryKey(2)).Returns(departamentDMAT);
            departamentRepositoryMock.Setup(p => p.FindByPrimaryKey(It.IsNotIn(1, 2))).Returns(null as Departament);

            return departamentRepositoryMock;
        }
        #endregion

        [Fact]
        public void GetAllDepartamentsTest()
        {
            var departamentRepositoryMock = CreateDepartamentRepositoryMock();
            var departamentService = new DepartamentService(departamentRepositoryMock.Object);

            var departaments = departamentService.GetAllDepartaments();
            Assert.Equal(2, departaments.Count());
        }

        [Fact]
        public void FindDepartamentByIdThatExistsTest()
        {
            var departamentRepositoryMock = CreateDepartamentRepositoryMock();
            var departamentService = new DepartamentService(departamentRepositoryMock.Object);

            var departament1 = departamentService.GetDepartamentById(1);
            var departament2 = departamentService.GetDepartamentById(2);

            Assert.Equal("DCC", departament1.Name);
            Assert.Equal("DMAT", departament2.Name);
        }

        [Fact]
        public void FindDepartamentByIdThatDoesNotExistsTest()
        {
            var departamentRepositoryMock = CreateDepartamentRepositoryMock();
            var departamentservice = new DepartamentService(departamentRepositoryMock.Object);

            Assert.Throws<BadHttpRequestException>(() => departamentservice.GetDepartamentById(0));
            Assert.Throws<BadHttpRequestException>(() => departamentservice.GetDepartamentById(3));
        }

        [Fact]
        public void FindDepartamentByIdConverterTest()
        {
            var departamentRepositoryMock = CreateDepartamentRepositoryMock();
            var departamentService = new DepartamentService(departamentRepositoryMock.Object);

            var departament1 = departamentService.GetDepartamentById(1);

            Assert.IsType<DepartamentModel>(departament1);
        }
    }
}
