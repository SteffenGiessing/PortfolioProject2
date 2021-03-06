using AutoMapper;
using WebApplication.DMOs;

namespace WebApplication.ViewModels
{
    public class AnotherProfile : Profile
    {
        public AnotherProfile()
        {
            CreateMap<TitleSearch, SearchViewModel>();
            CreateMap<TitleSearch, SearchListViewModel>();
        }
    }
}