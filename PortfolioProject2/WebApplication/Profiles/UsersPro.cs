using AutoMapper;
using PortfolioProject2.Models.DMOs;
using WebApplication.DTOs;

namespace WebApplication.Profiles
{
    public class UsersPro : Profile
    {
        public UsersPro()
        {
            CreateMap<UserToCreateOrLogin, User_User>();
            CreateMap<User_User, UserToCreateOrLogin>();
        }
    }
}


/*
using AutoMapper;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Profiles
{
    public class UsersPro : Profile
    {
        public UsersPro()
        {
            CreateMap<Users, User_User>();
            CreateMap<UserToCreate, Users>();
        }
    }
}
*/