using AutoMapper;
using WebApplication.DMOs;

namespace WebApplication.ViewModels
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Titles, TitleViewModel>();
            CreateMap<Titles, TitleListViewModel>();
        }
    }
}