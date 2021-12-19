using System;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Xunit;
using Moq;
using WebApplication.DataServices;
using WebApplication.DMOs;
using UserDataService = WebApplication.DataServices.UserDataService;

namespace WebApplication.Test
{
    public class UnitTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private const int Port = 5000;

        /*[Fact]
        public void TitleSearch()
        {
            var service = new TitleDataService();
            var search = service.TitleSearch("war").Result;
            Assert.Equal("Star Wars: Episode VII - The Force Awakens", search.First().PrimaryTitle);
        }*/

        [Fact]
        public void GetTitleById()
        {
            var service = new TitleDataService();
            var titles = service.GetTitleById("tt8769260").Result;
            Assert.Equal("Encounter", titles.First().PrimaryTitle);
        }

        //dont know why this one is failing
        [Fact]
        public void GetTitleByName()
        {
            var service = new TitleDataService();
            var titles = service.GetTitleByName("Encounter").Result;
            Assert.Equal("tt8769260", titles.First().TitleId);
        }

        [Fact]
        public void GetInfoSpecificTitle()
        {
            var service = new TitleDataService();
            var titles = service.GetInfoSpecificTitle("tt8690890").Result;
            Assert.Equal("Drama,Romance", titles.First().Genres);
        }

        [Fact]
        public void GetPersonKnownFor()
        {
            var service = new ActorDataService();
            var actor = service.GetPersonKnownFor("nm0000035").Result;
            Assert.Equal("tt0499549", actor.First().KnownForTitle);
        }

        [Fact]
        public void GetActorOnPid()
        {
            var service = new ActorDataService();
            var actor = service.GetActorOnPid("nm0000001").Result;
            Assert.Equal("Fred Astaire", actor.First().PrimaryName);
        }

        [Fact]
        public void GetPersonProfessionByActorId()
        {
            var service = new ActorDataService();
            var actor = service.GetPersonProfessionByActorId("nm0000001").Result;
            Assert.Equal("soundtrack", actor.First().Profession);
        }

        [Fact]
        public void GetRatingBy()
        {
            var service = new RatingsDataService();
            var rating = service.GetRatingBy("tt8769260").Result;
            Assert.Equal(604, rating.First().NumVotes);
        }

        [Fact]
        public void GetBestMatchPersonName()
        {
            var service = new ActorDataService();
            var actor = service.GetBestMatchPersonName("mads").Result;
            Assert.Equal("Michael Madsen", actor.First().PrimaryName);
        }

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
            var newHistorySearch = service.PostNewSearchHistory("something", 1);
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
                LastAccess = Convert.ToDateTime(DateTime.Now),
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