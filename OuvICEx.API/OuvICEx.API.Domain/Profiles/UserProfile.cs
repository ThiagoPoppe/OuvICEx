using AutoMapper;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreationModel, User>().ForMember(f => f.Id, dest => dest.Ignore())
                .ForMember(f => f.Departament, dest => dest.Ignore());

            CreateMap<User, UserModel>();
        }
    }
}
