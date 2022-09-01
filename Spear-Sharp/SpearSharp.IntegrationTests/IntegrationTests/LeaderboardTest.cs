using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpearSharp.IntegrationTests.IntegrationTests
{
    public class LeaderboardTest
    {
        [Fact]
        public async void GetKingdomsLeaderboardDTOs_Test()
        {
            var factory = new CustomWebApplicationFactory<Program>();
            HttpClient httpClient = factory.CreateClient();
            var response = await httpClient.GetAsync($"leaderboards/kingdoms");
            var expectedStatusCode = 200;

            var actualStatusCode = (int)response.StatusCode;

            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
        [Fact]
        public async void GetBuildingsLeaderboardDTOs_Test()
        {
            var factory = new CustomWebApplicationFactory<Program>();
            HttpClient httpClient = factory.CreateClient();
            var response = await httpClient.GetAsync($"leaderboards/buildings");
            var expectedStatusCode = 200;

            var actualStatusCode = (int)response.StatusCode;

            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
        [Fact]
        public async void GetTroopsLeaderboardDTOs_Test()
        {
            var factory = new CustomWebApplicationFactory<Program>();
            HttpClient httpClient = factory.CreateClient();
            var response = await httpClient.GetAsync($"leaderboards/troops");
            var expectedStatusCode = 200;

            var actualStatusCode = (int)response.StatusCode;

            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
    }
}
