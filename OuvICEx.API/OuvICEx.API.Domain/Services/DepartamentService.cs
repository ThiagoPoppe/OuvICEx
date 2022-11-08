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
    public class DepartamentService : IDepartamentService
    {
        private readonly IDepartamentRepository _repository;
        protected readonly IMapper _mapper;

        public DepartamentService(IDepartamentRepository repository)
        {
            _repository = repository;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DepartamentProfile>();
            });
            _mapper = configuration.CreateMapper();
        }

        public IEnumerable<DepartamentModel> GetAllDepartaments()
        {
            var departaments = _repository.GetAllEntities();
            return _mapper.Map<IEnumerable<DepartamentModel>>(departaments);
        }

        public DepartamentModel GetDepartamentById(int id)
        {
            var departament = _repository.FindByPrimaryKey(id);
            if (departament == null)
            {
                throw new BadHttpRequestException("Id doesn't exists");
            }
            return _mapper.Map<DepartamentModel>(departament);
        }

        public void CreateDepartament(DepartamentCreationModel departament)
        {            
            _repository.AddEntity(_mapper.Map<Departament>(departament));
        }
        

    }
}
