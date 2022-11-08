using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Domain.Interfaces.Service
{
    public interface IDepartamentService
    {
        public IEnumerable<DepartamentModel> GetAllDepartaments();
        public void CreateDepartament(DepartamentCreationModel departament);
        DepartamentModel GetDepartamentById(int id);
    }
}
