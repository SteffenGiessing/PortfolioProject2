using AutoMapper;
using PortfolioProject2.Models.DMOs;

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