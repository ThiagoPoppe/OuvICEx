using AutoMapper;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Domain.Profiles
{
    public class PublicationProfile : Profile
    {
        private bool HasTargetDepartament(Publication publication)
            => publication.TargetDepartament != null;

        private bool HasUserAndDepartament(Publication publication)
            => publication.User != null && publication.User.Departament != null;

        public PublicationProfile()
        {
            CreateMap<Publication, PublicationModel>()
                .ForMember(f => f.AuthorDepartamentName, dest => dest.MapFrom(src => HasUserAndDepartament(src) ? src.User.Departament.Name : null))
                .ForMember(f => f.TargetDepartamentName, dest => dest.MapFrom(src => HasTargetDepartament(src) ? src.TargetDepartament.Name : null));

            CreateMap<PublicationCreationModel, Publication>()
                .ForMember(f => f.Id, dest => dest.Ignore())
                .ForMember(f => f.User, dest => dest.Ignore())
                .ForMember(f => f.Status, dest => dest.Ignore())
                .ForMember(f => f.TargetDepartament, dest => dest.Ignore());
        }
    }
}
