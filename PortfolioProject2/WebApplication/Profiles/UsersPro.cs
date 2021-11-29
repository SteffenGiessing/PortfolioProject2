using AutoMapper;
using PortfolioProject2.DMOs;
using WebApplication.DTOs;
using User_User = WebApplication.DMOs.User_User;

namespace WebApplication.Profiles
{
    public class UsersPro : Profile
    {
        public UsersPro()
        {
            CreateMap<User_User, User_User_Dto>();
            CreateMap<UserCreateOrUpdate, User_User>();
        }
    }
}
