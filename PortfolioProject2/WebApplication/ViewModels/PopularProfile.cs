using AutoMapper;
using WebApplication.DMOs;

namespace WebApplication.ViewModels
{
    public class SomeProfile : Profile
    {
        public SomeProfile()
        {
            CreateMap<PopularTitles, PopularViewModel>();
            CreateMap<PopularTitles, PopularListViewModel>();
        }
    }
}