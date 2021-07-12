using WebApplication4.Core.Models;

namespace WebApplication4.Core
{
    public interface IWeatherForecastService
    {
        int Create(WeatherForecast weatherForecast);
        WeatherForecast Read(int Id);
        WeatherForecast[] ReadAll();
        void Update(WeatherForecast weatherForecast);
        void Delete(WeatherForecast weatherForecast);
    }
}