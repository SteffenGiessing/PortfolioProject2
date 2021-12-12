using AutoMapper;
using WebApplication.DMOs;

namespace WebApplication.ViewModels
{
    public class PopularProfile : Profile
    {
        public PopularProfile()
        {
            CreateMap<PopularTitles, PopularProfile>();
            CreateMap<PopularTitles, PopularListViewModel>();
        }
    }
}