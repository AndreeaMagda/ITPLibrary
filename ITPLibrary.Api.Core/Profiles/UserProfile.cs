using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Data.Entities;

namespace ITPLibrary.Api.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegistrationDto, User>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Email)); 
        }
    }
}
