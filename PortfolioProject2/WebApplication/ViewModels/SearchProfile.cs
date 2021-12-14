using AutoMapper;
using WebApplication.DMOs;

namespace WebApplication.ViewModels
{
    public class AnotherProfile : Profile
    {
        public AnotherProfile()
        {
            CreateMap<PopularTitles, SearchViewModel>();
            CreateMap<PopularTitles, SearchListViewModel>();
        }
    }
}