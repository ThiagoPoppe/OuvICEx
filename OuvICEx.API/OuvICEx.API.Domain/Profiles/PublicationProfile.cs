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

        private int? ConvertUserIdAttribute(PublicationCreationModel publicationCreationModel)
            => publicationCreationModel.UserId == 0 ? null : publicationCreationModel.UserId;
        
        private int? ConvertTargetDepartamentId(PublicationCreationModel publicationCreationModel)
            => publicationCreationModel.TargetDepartamentId == 0 ? null : publicationCreationModel.TargetDepartamentId;

        public PublicationProfile()
        {
            CreateMap<Publication, PublicationModel>()
                .ForMember(f => f.AuthorDepartamentName, dest => dest.MapFrom(src => HasUserAndDepartament(src) ? src.User.Departament.Name : null))
                .ForMember(f => f.TargetDepartamentName, dest => dest.MapFrom(src => HasTargetDepartament(src) ? src.TargetDepartament.Name : null));

            CreateMap<PublicationCreationModel, Publication>()
                .ForMember(f => f.Id, dest => dest.Ignore())
                .ForMember(f => f.User, dest => dest.Ignore())
                .ForMember(f => f.Status, dest => dest.Ignore())
                .ForMember(f => f.TargetDepartament, dest => dest.Ignore())
                .ForMember(f => f.UserId, dest => dest.MapFrom(src => ConvertUserIdAttribute(src)))
                .ForMember(f => f.TargetDepartamentId, dest => dest.MapFrom(src => ConvertTargetDepartamentId(src)));
        }
    }
}
