using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpearSharp.IntegrationTests.IntegrationTests
{
    public class AuthControllerTests
    {
        [Fact]
        public async void UnauthorizedAccess()
        {
            var factory = new CustomWebApplicationFactory<Program>();
            HttpClient httpClient = factory.CreateClient();

            var expectedStatusCode = 401;
            var response = await httpClient.GetAsync("auth");
            var actualStatusCode = (int)response.StatusCode;

            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
    }
}
