using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using ServerApp.Services;
using Xunit;

namespace UnitTests
{
    public class WeatherServiceTest
    {
        [Fact]
        public async Task CanRetrieveLocationByName()
        {
            using var host = await new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder
                        .UseTestServer()
                        .ConfigureServices(services =>
                        {
                            // services.AddHttpClient("MetaWeather", c =>
                            // {
                            //     c.BaseAddress = new Uri("https://www.metaweather.com/api/");
                            // });

                            // services.AddTransient<IWeatherSvc, WeatherService>();
                        })
                        .Configure(app =>
                        {
                            // app.UseMiddleware<IWeatherSvc>();
                        });
                })
                .StartAsync();

            var response = await host.GetTestServer().CreateClient().GetAsync("/");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task TestMiddleware_ExpectedResponse()
        {
            using var host = await new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder
                        .UseTestServer()
                        .ConfigureServices(services =>
                        {
                            // services.AddHttpClient("MetaWeather", c =>
                            // {
                            //     c.BaseAddress = new Uri("https://www.metaweather.com/api/");
                            // });

                            // services.AddTransient<IWeatherSvc, WeatherService>();
                        })
                        .Configure(app =>
                        {
                            app.UseMiddleware<IWeatherSvc>();
                        });
                })
                .StartAsync();

            // var server = host.GetTestServer();
            // server.BaseAddress = new Uri("https://example.com/A/Path/");

            // var context = await server.SendAsync(c =>
            // {
            //     c.Request.Method = HttpMethods.Post;
            //     c.Request.Path = "/and/file.txt";
            //     c.Request.QueryString = new QueryString("?and=query");
            // });

            // Assert.True(context.RequestAborted.CanBeCanceled);
            // Assert.Equal("POST", context.Request.Method);
            // Assert.Equal("https", context.Request.Scheme);
            // Assert.Equal("example.com", context.Request.Host.Value);
            // Assert.Equal("/A/Path", context.Request.PathBase.Value);
            // Assert.Equal("/and/file.txt", context.Request.Path.Value);
            // Assert.Equal("?and=query", context.Request.QueryString.Value);
            // Assert.NotNull(context.Request.Body);
            // Assert.NotNull(context.Request.Headers);
            // Assert.NotNull(context.Response.Headers);
            // Assert.NotNull(context.Response.Body);
            // Assert.Equal(404, context.Response.StatusCode);
            // Assert.Null(context.Features.Get<IHttpResponseFeature>().ReasonPhrase);
        }
    }
}
