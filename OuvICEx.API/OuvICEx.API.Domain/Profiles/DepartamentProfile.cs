using AutoMapper;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Domain.Profiles
{
    public class DepartamentProfile : Profile
    {
        public DepartamentProfile()
        {
            CreateMap<DepartamentCreationModel, Departament>().ForMember(f => f.Id, dest => dest.Ignore());
            CreateMap<Departament, DepartamentModel>();
        }
    }
}
