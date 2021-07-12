

using WebApplication4.Core.Models;

namespace WebApplication4.Core
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private IWeatherRepository _weatherRepository;
        public WeatherForecastService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }
        
        public int Create(WeatherForecast weatherForecast)
        {
            return _weatherRepository.Create(weatherForecast);
        }

        public WeatherForecast Read(int Id)
        {
            return _weatherRepository.Read(Id);
        }

        public WeatherForecast[] ReadAll()
        {
            return _weatherRepository.ReadAll();
        }

        public void Update(WeatherForecast weatherForecast)
        {
            _weatherRepository.Update(weatherForecast);
        }

        public void Delete(WeatherForecast weatherForecast)
        {
            _weatherRepository.Delete(weatherForecast);
        }
    }
}