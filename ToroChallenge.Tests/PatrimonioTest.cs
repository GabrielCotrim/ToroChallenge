using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ToroChallenge.Api;
using Xunit;

namespace ToroChallenge.Tests
{
    public class PatrimonioTest
    {
        private readonly HttpClient _client;
        public PatrimonioTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());

            _client = server.CreateClient();
        }

        [Fact]
        public async Task GetPatrimonioDoUsuario()
        {
            var uri = $"/api/patrimonio/GetUserPosition/1";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await _client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            dynamic obj = JObject.Parse(json);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
