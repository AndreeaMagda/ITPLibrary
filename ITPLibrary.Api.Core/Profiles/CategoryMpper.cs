using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Data.Entities;

namespace ITPLibrary.Api.Core.Profiles
{
    public class CategoryMapper: Profile
    {
        public CategoryMapper()
        {
            
           CreateMap<Category, CategoryDto>().ReverseMap();
        }
        
    }
}
