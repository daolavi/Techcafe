using AutoMapper;
using TechCafe.Repository.Entities;

namespace TechCafe.Api
{
    // When application start, Automapper will go through looking for classes that inherit from 'Profile'
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, Models.UserModel>();
        }
    }
}
