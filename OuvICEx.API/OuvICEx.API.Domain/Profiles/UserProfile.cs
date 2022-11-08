using AutoMapper;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Models;

namespace OuvICEx.API.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, User>().ForMember(f => f.Id, dest => dest.Ignore())
                .ForMember(f => f.Departament, dest => dest.Ignore());
            //CreateMap<Form, Form>()
            //    .ForMember(f => f.Id, dest => dest.Ignore());

            //CreateMap<Form, FormModel>()
            //    .ForMember(f => f.FormId, dest => dest.MapFrom(src => src.Id))
            //    .ForMember(f => f.Title,
            //        dest => dest.MapFrom(src =>
            //            src.FormLocales.Any()
            //                ? src.FormLocales.First().Title
            //                : src.Title ?? string.Empty))
            //    .ForMember(f => f.Description,
            //        dest => dest.MapFrom(src =>
            //            src.FormLocales.Any()
            //                ? src.FormLocales.First().Description
            //                : src.Description ?? string.Empty));

            //CreateMap<FormModel, Form>()
            //    .ForMember(f => f.Id, dest => dest.MapFrom(src => src.FormId));

            //CreateMap<EditableFormModel, Form>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FormId))
            //    .ForMember(dest => dest.Title, opt => opt.Ignore())
            //    .ForMember(dest => dest.Description, opt => opt.Ignore());

            //CreateMap<Form, EditableFormModel>()
            //    .ForMember(f => f.FormId, dest => dest.MapFrom(src => src.Id))
            //    .ForMember(f => f.Title, dest => dest.Ignore())
            //    .ForMember(f => f.Description, dest => dest.Ignore());
        }
    }
}
