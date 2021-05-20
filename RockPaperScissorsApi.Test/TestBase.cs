using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace RockPaperScissorsApi.Test
{
    public class TestBase : IDisposable
    {
        protected readonly IHost TestWebServer;

        protected TestBase()
        {
            TestWebServer = CreateServer();
        }

        private static IHost CreateServer()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
            var hostBuilder = new HostBuilder()
                .ConfigureLogging(builder => { builder.AddConsole(); })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseTestServer();
                    webBuilder.UseStartup<Startup>();
                });

            var testServer = hostBuilder.Start();
            return testServer;
        }

        protected static class Get
        {
            public const string WelcomeScreen = "/";
            public const string Scoreboard = "/scoreboard";
        }

        protected static class Post
        {
            public const string CreateNewGame = "/new-game";
            public static string Play(string gameId) => $"/game/{gameId}/play";
        }

        protected async Task<HttpResponseMessage> PostAsync(string endpoint, HttpContent requestBody) =>
            await this.TestWebServer.GetTestClient().PostAsync(endpoint, requestBody);

        protected async Task<HttpResponseMessage> GetAsync(string endpoint) =>
            await this.TestWebServer.GetTestClient().GetAsync(endpoint);

        protected static StringContent CreateRequestBody<T>(T t) =>
            new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");

        protected static T ReadResponseBody<T>(string responseBody) => JsonConvert.DeserializeObject<T>(responseBody);

        public void Dispose()
        {
            TestWebServer.StopAsync();
        }
    }
}