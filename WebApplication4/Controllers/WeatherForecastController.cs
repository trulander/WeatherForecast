using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication4.Core;
using WebApplication4.Models;


namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IWeatherForecastService _weatherForecastService;
        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpPut("update")]
        public void Update(WeatherForecast weatherForecast)
        {
            _weatherForecastService.Update(new Core.Models.WeatherForecast
            {
                Id = weatherForecast.Id,
                Date = weatherForecast.Date,
                TemperatureC = weatherForecast.TemperatureC,
                Summary = weatherForecast.Summary,
                Comment = weatherForecast.Comment
            });
        }
        
        [HttpDelete("delete")]
        public void Delete(int Id)
        {
            _weatherForecastService.Delete(new Core.Models.WeatherForecast
            {
                Id = Id
            });
        }
        
        [HttpPost("create")]
        public int Create(WeatherForecast weatherForecast)
        {
            var result = _weatherForecastService.Create(new Core.Models.WeatherForecast
            {
                Date = weatherForecast.Date,
                TemperatureC = weatherForecast.TemperatureC,
                Summary = weatherForecast.Summary,
                Comment = weatherForecast.Comment
            });
            return result;
        }
        
        [HttpGet("read")]
        public WeatherForecast Read(int Id)
        {
            var model = _weatherForecastService.Read(Id);
            return new WeatherForecast(model.Id, model.Date, model.TemperatureC, model.Summary,model.Comment);
        }

        [HttpGet("readall")]
        public WeatherForecast[] ReadAll()
        {
            var result = new List<WeatherForecast>();
            foreach (var weatherForecast in _weatherForecastService.ReadAll())
            {
                result.Add(new WeatherForecast(weatherForecast.Id,weatherForecast.Date,weatherForecast.TemperatureC,weatherForecast.Summary,weatherForecast.Comment));
            }

            return result.ToArray();
        }
        
        [HttpGet("generatetestmodels")]
        public void GenerateTestModels()
        {
            var rng = new Random();

            var weatherForecasts = Enumerable.Range(1, 10).Select(index => new Core.Models.WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                Comment = Summaries[rng.Next(Summaries.Length)]
            });

            foreach (var weatherForecast in weatherForecasts)
            {
                _weatherForecastService.Create(weatherForecast);
            }
        }
    }
}