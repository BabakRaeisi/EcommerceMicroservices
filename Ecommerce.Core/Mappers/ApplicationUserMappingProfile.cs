using AutoMapper;
using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;

namespace Ecommerce.Core.Mappers; 
 
    public class ApplicationUserMappingProfile : Profile
    { public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>().ForMember
            (dest => dest.Token, opt => opt.Ignore())
            .ForMember(dest => dest.IsSuccessful, opt => opt.Ignore())
            .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName));
       
    }
}
 
