using System;
using System.Threading.Tasks;
using ServerApp.Models;

namespace ServerApp.Services
{
    public interface IWeatherSvc
    {
        Task<ForecastHistory[]> GetForecastHistoryAsync(string oeid, string date);
        Task<Forecast> GetLocationForecastByOEIDAsync(long oeid);
        Task<Location[]> GetLocationByNameAsync(string name);
        Task<ConsolidatedWeather[]> GetWeatherForecastAsync(string name);
    }
}
