using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpearSharp.Database;
using System.Text;

namespace SpearSharp.IntegrationTests.IntegrationTests
{
    public class ApiControllerTests
    {

        [Fact]
        public async void UnauthorizedResponseIfKingdomIdNotFound()
        {
            var factory = new CustomWebApplicationFactory<Program>();
            HttpClient httpClient = factory.CreateClient();
            int id = 35423;
            var response = await httpClient.GetAsync($"api/kingdoms/{id}");
            var expectedStatusCode = 401;

            var actualStatusCode = (int)response.StatusCode;

            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public async void KingdomResponseSuccessful()
        {
            var factory = new CustomWebApplicationFactory<Program>();
            HttpClient httpClient = factory.CreateClient();
            int id = 1;
            var response = await httpClient.GetAsync($"api/kingdoms/{id}");
            var expectedStatusCode = 200;

            var actualStatusCode = (int)response.StatusCode;

            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public async void RegistrationResponseSuccessful()
        {
            var factory = new CustomWebApplicationFactory<Program>();
            HttpClient httpClient = factory.CreateClient();
            var content = new
            {
                username = "Dezider",
                password = "123452523423",
                kingdomName = "Letanovce",
                email = "dezkozosady@gipsy.sk"
            };
            //in the next step we change json to string because PostAsync doesnt accept json
            string stringContent = JsonConvert.SerializeObject(content);
            //here we wrap it to httpContent
            HttpContent httpContent = new StringContent(stringContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"api/registration", httpContent);
            var expectedStatusCode = 200;

            var actualStatusCode = (int)response.StatusCode;

            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public async void PasswordIsTooShort()
        {
            var factory = new CustomWebApplicationFactory<Program>();
            HttpClient httpClient = factory.CreateClient();
            var content = new
            {
                username = "Dezider",
                password = "1234",
                kingdomName = "Letanovce",
                email = "dezkozosady@gipsy.sk"
            };
            string stringContent = JsonConvert.SerializeObject(content);
            var httpContent = new StringContent(stringContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"api/registration", httpContent);
            var expectedMessage = new { error = "Your password is too short" };

            var actualMessage = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content.ReadAsStringAsync().Result);

            Assert.Equal(expectedMessage.error, actualMessage["error"]);
        }
    }
}