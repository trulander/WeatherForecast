

using WebApplication4.Core.Models;

namespace WebApplication4.Core
{
    public interface IWeatherRepository
    {
        int Create(WeatherForecast weatherForecast);
        WeatherForecast Read(int Id);
        WeatherForecast[] ReadAll();
        bool Update(WeatherForecast weatherForecast);
        bool Delete(WeatherForecast weatherForecast);
    }
}