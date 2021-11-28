using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Xunit;
using PortfolioProject2;

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
            var newBookmark = service.CreateTitleBookmark("user69", "tt11827694");
            Assert.NotNull(newBookmark);
            Assert.Equal(newBookmark, service.GetTitleBookmark("user69", "tt11827694"));
            service.DeleteTitleBookmark("user69", "tt11827694");
            Assert.Null(service.GetTitleBookmark("user69", "tt11827694"));
        }
    }
}