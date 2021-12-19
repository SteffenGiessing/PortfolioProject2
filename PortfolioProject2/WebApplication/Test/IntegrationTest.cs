using System;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication.DTOs;
using Xunit;
using HttpMethod = Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

namespace WebApplication.Test
{
    /*
    * Integration Testing
    */
    public class IntegrationTest
    {
        private const string UserApi = "http://localhost:5000/api/user";

        private const string TitleApi = "http://localhost:5000/api/titles";

        /*
         * User specific test
         */
        [Fact]
        public void Wrong_LoginUser()
        {
            string specificUserUrl = UserApi + "login";
            var newUser = new
            {
                EmailAddress = "1@asda",
                Password = "1"
            };
            var (user, statuscode) = Post(specificUserUrl, newUser);

            Assert.Equal(HttpStatusCode.NotFound, statuscode);
        }

        [Fact]
        public void LoginUser()
        {
            string specificUserUrl = UserApi + "/login";
            var newUser = new
            {
                EmailAddress = "@A",
                Password = "1"
            };
            var (user, statuscode) = Post(specificUserUrl, newUser);

            Assert.Equal(HttpStatusCode.OK, statuscode);
        }

        [Fact]
        public void Create_User()
        {
            string specificUserUrl = UserApi + "/create";
            var newUser = new
            {
                FirstName = "testfirstname",
                LastName = "testlastname",
                UserName = "usernameTest",
                EmailAddress = "test@test.com",
                Password = "100"
            };
            var (user, statuscode) = Post(specificUserUrl, newUser);
            Assert.Equal(HttpStatusCode.OK, statuscode);

            var deleteUser = new
            {
                EmailAddress = "test@test.com"
            };
            //Clean up
            var (userDelete, statuscodeDelete) = Delete("http://localhost:5000/api/user/deleteuser", deleteUser);
            Assert.Equal(HttpStatusCode.OK, statuscodeDelete);
        }

        [Fact]
        public void Wrong_Create_User()
        {
            string specificUserUrl = UserApi + "/create";
            var newUser = new
            {
                FirstName = "testfirstname",
                LastName = "testlastname",
                UserName = "usernameTest",
                EmailAddress = "testtest.com",
                Password = "100"
            };
            var (user, statuscode) = Post(specificUserUrl, newUser);
            Assert.Equal(HttpStatusCode.NotFound, statuscode);
        }

        [Fact]
        public void Search_Movie_Result()
        {
            var foundTitle = "nothing";
            string specificTitleUrl = TitleApi + "/searchresult/star";
            var (data, statusCode) = Get(specificTitleUrl);

            Assert.Equal(HttpStatusCode.OK, statusCode);
            foreach (var findTitle in data)
            {
                string title = findTitle["primaryTitle"].ToString();
                if (title == "Star Wars: Episode VII - The Force Awakens")
                {
                    foundTitle = title;
                }
            }

            Assert.Equal("Star Wars: Episode VII - The Force Awakens", foundTitle);
        }

        (JObject, HttpStatusCode) Post(string url, object body)
        {
            var client = new HttpClient();
            var contentRequest = new StringContent(
                JsonConvert.SerializeObject(body),
                Encoding.UTF8,
                "application/json");
            var response = client.PostAsync(url, contentRequest).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject) JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JObject, HttpStatusCode) Delete(string url, object body)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(System.Net.Http.HttpMethod.Delete, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var response = client.SendAsync(request).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject) JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JArray, HttpStatusCode) Get(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JArray) JsonConvert.DeserializeObject(data), response.StatusCode);
        }
    }
}