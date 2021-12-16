using System;
using System.Net.Sockets;
using System.Security.Cryptography;
using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Xunit;
using Moq;
using PortfolioProject2.Models.DataServices;
using PortfolioProject2.Models.DMOs;
using WebApplication.DataServices;
using WebApplication.DMOs;
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
        
        //createuser and login 
        [Fact]
        public void CreateUser()
        {
            var service = new UserDataService();
            var dataProvider = UserCreatorHelper();
            
            //act
            var create = service.CreateUser(dataProvider).Result;
            
            //Assertion
            Assert.Equal(dataProvider.EmailAddress, create.EmailAddress);
            
            //Clean up
            var deleteCreatedUser = service.DeleteUser(create).Result;
        }

        [Fact]
        public void LoginUser()
        {
            var service = new UserDataService();
            var dataProvider = UserCreatorHelper();

            //Act
            var create = service.CreateUser(dataProvider).Result;
            //Assertion
            Assert.Equal(dataProvider.EmailAddress, create.EmailAddress);

            var validatePassword = service.ValidatePassword(dataProvider.EmailAddress, dataProvider.Password).Result;
            Assert.NotNull(validatePassword);
            
            //Clean up
            var deleteCreatedUser = service.DeleteUser(create).Result;

        }
        
        //bookmarks
        [Fact]
        public void CreateTitleBookmark()
        {
            var service = new BookMarkDataService();
            var newBookmark = service.CreateTitleBookmark(99, "tt11827694");
            /*Assert.Equal(newBookmark, service.GetTitleBookmark(3, "tt11827694"));
            service.DeleteTitleBookmark(3, "tt11827694");
            /*Assert.NotNull(newBookmark);
            Assert.Equal(newBookmark, service.GetTitleBookmark("7", "tt11827694"));
            service.DeleteTitleBookmark("7", "tt11827694");
            Assert.Null(service.GetTitleBookmark("3", "tt11827694"));*/
        }
        
        [Fact]
        public void GetTitleBookmarks()
        {
            var service = new BookMarkDataService();
            var bookmarks = service.GetTitleBookmarks(1);
            Assert.Equal(3, bookmarks.Count);
        }
        
        [Fact]
        public void GetNameBookmarks()
        {
            var service = new BookMarkDataService();
            var bookmarks = service.GetNameBookmarks(1);
            Assert.Equal(1, bookmarks.Count);
        }
        
        //comments
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
       //     var comments = service.GetUserComments(1);
        //    Assert.Equal(3, comments.Count);
        }
        
        [Fact]
        public void CreateTitleComments()
        {
            var service = new CommentsDataService();
        //    var newComment = service.CreateTitleComments(1, "tt10850402", "meh 2");
        }

        //searchhistory
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
        private static User_User UserCreatorHelper()
        {
            var dataProvider = new User_User
            {
                FirstName = "Bob",
                LastName = "Jensen",
                EmailAddress = "Jensen@gmail.com",
                UserName = "Bobben",
                Password = "Rasputin",
                LastAccess =  Convert.ToDateTime(DateTime.Now),
                TokenJwt = "null"
            };
               
            byte[] getsalt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(getsalt);
            }
                
            string getHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: dataProvider.Password,
                salt: getsalt,
                prf: KeyDerivationPrf.HMACSHA1, 
                iterationCount: 10000, 
                numBytesRequested: 256 / 8));
            
            dataProvider.Password = getHash;
            dataProvider.PasswordSalt = getsalt;
            return dataProvider;
        }
    }
}