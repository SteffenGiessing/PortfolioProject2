using System;
using System.Net.Sockets;
using AutoMapper;
using Xunit;
using Moq;
using Newtonsoft.Json;
using PortfolioProject2.Models.DataServices;
using ActorDataService = WebApplication.DataServices.ActorDataService;
using UserDataService = WebApplication.DataServices.UserDataService;

namespace WebApplication.Test
{
    public class UnitTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private const int Port = 5000;
        
        [Fact]
        public void CheckConnection()
        {
            var client = Connect();
            Assert.True(client.Connected);
        }
        
        [Fact]
        public void CreateTitleBookmark()
        {
            var service = new TitleDataService();
            var newBookmark = service.CreateTitleBookmark("7", "tt11827694");
            /*Assert.NotNull(newBookmark);
            Assert.Equal(newBookmark, service.GetTitleBookmark("7", "tt11827694"));
            service.DeleteTitleBookmark("7", "tt11827694");
            Assert.Null(service.GetTitleBookmark("3", "tt11827694"));*/
        }
        
        [Fact]
        public void GetTitleBookmarks()
        {
            var service = new TitleDataService();
            var bookmarks = service.GetTitleBookmarks("1");
            Assert.Equal(2, bookmarks.Count);
        }
        
        [Fact]
        public void GetNameBookmarks()
        {
            var service = new ActorDataService();
            var bookmarks = service.GetNameBookmarks("1");
            Assert.Equal(1, bookmarks.Count);
        }
        
        [Fact]
        public void TestingUserSearchHistorybyUserId()
        {
            //Arrange
            var service = new UserDataService();
            var newHistorySearch = service.PostNewSearchHistory("1", "some random movie again new test");
        }
        
        [Fact]
        public void ShowUserSearchHistoryById()
        {
            var service = new UserDataService();
            var searching = service.GetAllSearchHistoryFromOneUser("1");
            Assert.Equal(3, searching.Count);
        }
        
        // Helper Methods
        private static TcpClient Connect()
        {
            var client = new TcpClient();
            client.Connect("localhost", Port);
            return client;
        }

        [Fact]
        public void ShouldSeeAllCommentsFromOneUser()
        {
            var service = new UserDataService();
            var getAllComments = service.GetAllCommentsFromOneUser("1");
            Assert.NotNull(getAllComments);
            Assert.Equal(1, getAllComments.Id);
            

        }
       // Assert.Equal(2, bookmarks.Count);
    }
}