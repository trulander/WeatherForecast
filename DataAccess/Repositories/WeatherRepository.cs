using System.Collections.Generic;
using System.Linq;
using DataAccess.Contexts;
using WebApplication4.Core;
using WebApplication4.Core.Models;

namespace DataAccess.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private WeatherContextDb _contextDb;
        
        public WeatherRepository(WeatherContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public int Create(WeatherForecast weatherForecast)
        {
           var result = _contextDb.WeatherForecasts.Add(new WebApplication4.DataLayer.Entities.WeatherForecast
            {
                Date = weatherForecast.Date,
                TemperatureC = weatherForecast.TemperatureC,
                Summary = weatherForecast.Summary,
                Comment = weatherForecast.Comment
            });
           _contextDb.SaveChanges();
           return result.Entity.Id;
        }

        public WeatherForecast Read(int Id)
        {
            var entity = _contextDb.WeatherForecasts.FirstOrDefault(weatherForecast => weatherForecast.Id == Id);
            return new WeatherForecast
            {
                Id = entity.Id,
                Date = entity.Date,
                TemperatureC = entity.TemperatureC,
                Summary = entity.Summary,
                Comment = entity.Comment
            };
        }

        public WeatherForecast[] ReadAll()
        {
            var result = new List<WeatherForecast>();
            foreach (var weatherForecast in _contextDb.WeatherForecasts)
            {
                result.Add(new WeatherForecast
                {
                    Id = weatherForecast.Id,
                    Date = weatherForecast.Date,
                    TemperatureC = weatherForecast.TemperatureC,
                    Summary = weatherForecast.Summary,
                    Comment = weatherForecast.Comment
                });
            }

            return result.ToArray();
        }

        public bool Update(WeatherForecast weatherForecast)
        {
            var result = _contextDb.WeatherForecasts.Update(new WebApplication4.DataLayer.Entities.WeatherForecast
            {
                Id = weatherForecast.Id,
                Date = weatherForecast.Date,
                TemperatureC = weatherForecast.TemperatureC,
                Summary = weatherForecast.Summary,
                Comment = weatherForecast.Comment
            });
            _contextDb.SaveChanges();
            return result.IsKeySet;
        }

        public bool Delete(WeatherForecast weatherForecast)
        {
            var result = _contextDb.WeatherForecasts.Remove(new WebApplication4.DataLayer.Entities.WeatherForecast
            {
                Id = weatherForecast.Id
            });
            _contextDb.SaveChanges();
           return result.IsKeySet;
        }
    }
}