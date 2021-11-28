using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using Moq;
using PortfolioProject2;
using PortfolioProject2.Models.DataServices;

namespace WebApplication.Test
{
    public class UnitTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private const int Port = 5000;
        
        [Fact]
        public void CheckConnection()
        {
            
        }
        
        [Fact]
        public void CreateTitleBookmark()
        {
            var service = new TitleDataService();
            var newBookmark = service.CreateTitleBookmark("6", "tt11827694");
            //Assert.NotNull(newBookmark);
            //Assert.Equal(newBookmark, service.GetTitleBookmark("4", "tt11827694"));
            //service.DeleteTitleBookmark("3", "tt11827694");
           // Assert.Null(service.GetTitleBookmark("3", "tt11827694"));
        }
        
    }
}