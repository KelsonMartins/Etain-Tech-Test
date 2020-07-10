using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ServerApp.Models;
using ServerApp.Services;

namespace ServerApp.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherSvc _svc;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherSvc svc)
        {
            _logger = logger;
            _svc = svc;
        }

        /// <summary>
        /// Returns a list of locations given search query.
        /// </summary>
        /// <param name="query"></param>
        /// <response code="200">Returns location results</response>
        /// <response code="400">Request with invalid or null query param</response>      
        /// <response code="401">Unauthorized request. Invalid or unauthenticated user.</response>      
        [HttpGet("location/{query}", Name = "get-weather-location")]
        [ProducesResponseType(typeof(Location), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetWeatherLocationAsync(string query)
            => (!string.IsNullOrWhiteSpace(query))
                ? Ok(await _svc.GetLocationByNameAsync(query))
                : (IActionResult)BadRequest("Please, provide a location for querying Weather.");

        /// <summary>
        /// Returns a list of Weather Forecast predications given search query.
        /// </summary>
        /// <param name="query"></param>
        /// <response code="200">Returns Weather Forecast results</response>
        /// <response code="400">Request with invalid or null query param</response>      
        /// <response code="401">Unauthorized request. Invalid or unauthenticated user.</response>      
        [HttpGet("{query}", Name = "get-weather-forecast")]
        [ProducesResponseType(typeof(ConsolidatedWeather[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetWeatherForecastAsync(string query)
            => (!string.IsNullOrWhiteSpace(query))
                ? Ok(await _svc.GetWeatherForecastAsync(query))
                : (IActionResult)BadRequest("Please, provide a location for accurate Weather forecast.");

        /// <summary>
        /// Returns a list of location forecast given On Earth ID.
        /// </summary>
        /// <param name="oeid"></param>
        /// <response code="200">Returns location results</response>
        /// <response code="400">Request with invalid or null query param</response>      
        /// <response code="401">Unauthorized request. Invalid or unauthenticated user.</response>      
        [HttpGet("forecast/{oeid}", Name = "get-location-forecast")]
        [ProducesResponseType(typeof(Forecast), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetWeatherLocationForecastAsync(long oeid)
            => (oeid <= 0)
                ? Ok(await _svc.GetLocationForecastByOEIDAsync(oeid))
                : (IActionResult)BadRequest("Please, provide a valid On Earth Id for accurate Weather Forecast.");
    }
}
