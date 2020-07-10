using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

using ServerApp.Models;
using System.Linq;

namespace ServerApp.Services
{
    public class WeatherService : IWeatherSvc
    {
        public WeatherService(IHttpClientFactory client)
        {
            _client = client;
        }

        private readonly IHttpClientFactory _client;

        /// <summary>
        /// Returns a Weather Forecast given Location name.
        /// </summary>
        /// <param name="name">Text to search for</param>
        /// <returns>Location</returns>
        public async Task<ConsolidatedWeather[]> GetWeatherForecastAsync(string name)
        {
            var location = await GetLocationByNameAsync(name);

            if (location.Any())
            {
                var woeid = location.Select(x => x.Woeid).FirstOrDefault();
                var result = await GetLocationForecastByOEIDAsync(woeid);

                return result.ConsolidatedWeather; ;
            }
            else
            {
                return Array.Empty<ConsolidatedWeather>();
            }
        }

        /// <summary>
        /// Find a location by given query name
        /// </summary>
        /// <param name="name">Text to search for</param>
        /// <returns>Location</returns>
        public async Task<Location[]> GetLocationByNameAsync(string name)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"location/search/?query={name}");
            var client = _client.CreateClient("MetaWeather");

            using var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Location[]>(result);
            }
            else
            {
                return Array.Empty<Location>();
            }
        }

        /// <summary>
        /// Location information, and a 5 day forecast
        /// </summary>
        /// <param name="oeid">Where On Earth ID</param>
        /// <returns>Forecast</returns>
        public async Task<Forecast> GetLocationForecastByOEIDAsync(long oeid)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"location/{oeid}");
            var client = _client.CreateClient("MetaWeather");

            using var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Forecast>(result);
            }
            else
            {
                return new Forecast();
            }
        }

        /// <summary>
        /// Source information and forecast history for a particular day and location
        /// </summary>
        /// <param name="oeid">Where On Earth ID</param>
        /// <param name="date">Date in the format yyyy/mm/dd. Most location have data from early 2013 to 5-10 days in the future</param>
        /// <returns>ForecastHistory[]</returns>
        public async Task<ForecastHistory[]> GetForecastHistoryAsync(string oeid, string date)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"location/{oeid}/date");
            var client = _client.CreateClient("MetaWeather");

            using var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ForecastHistory[]>(result);
            }
            else
            {
                return Array.Empty<ForecastHistory>();
            }
        }

    }
}
