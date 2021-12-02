using System.Net.Sockets;
using AutoMapper;
using Xunit;
using Moq;
using PortfolioProject2.Models.DataServices;
using WebApplication.DataServices;
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
            var service = new BookMarkDataService();
            var newBookmark = service.CreateTitleBookmark("20", "tt11827694");
            /*Assert.NotNull(newBookmark);
            Assert.Equal(newBookmark, service.GetTitleBookmark("7", "tt11827694"));
            service.DeleteTitleBookmark("7", "tt11827694");
            Assert.Null(service.GetTitleBookmark("3", "tt11827694"));*/
        }
        
        [Fact]
        public void GetTitleBookmarks()
        {
            var service = new BookMarkDataService();
            var bookmarks = service.GetTitleBookmarks("1");
            Assert.Equal(3, bookmarks.Count);
        }
        
        [Fact]
        public void GetNameBookmarks()
        {
            var service = new BookMarkDataService();
            var bookmarks = service.GetNameBookmarks("1");
            Assert.Equal(1, bookmarks.Count);
        }
        
        [Fact]
        public void GetCommentsFromTitle()
        {
            var service = new CommentsDataService();
            var comments = service.GetCommentsFromTitle("tt10850402");
            Assert.Equal(3, comments.Count);
        }
        
        [Fact]
        public void GetUserComments()
        {
            var service = new CommentsDataService();
            var comments = service.GetUserComments(1);
            Assert.Equal(3, comments.Count);
        }
        
        [Fact]
        public void CreateTitleComments()
        {
            var service = new CommentsDataService();
            var newComment = service.CreateTitleComments(1, "tt10850402", "meh 2");
        }

        [Fact]
        public void TestingUserSearchHistorybyUserId()
        {
            //Arrange
            var service = new SearchHistoryDataService();
            var newHistorySearch = service.PostNewSearchHistory("something",1);
        }

        [Fact]
        public void ShowUserSearchHistoryById()
        {
            var service = new SearchHistoryDataService();
            var searching = service.GetAllSearchHistoryFromOneUser(1);
            Assert.Equal(6, searching.Count);
        }
        
        // Helper Methods
        private static TcpClient Connect()
        {
            var client = new TcpClient();
            client.Connect("localhost", Port);
            return client;
        }
        
    }
}