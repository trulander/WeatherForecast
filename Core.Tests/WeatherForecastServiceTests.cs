using AutoFixture;
using Moq;
using WebApplication4.Controllers.Models;

namespace WebApplication4.Core.Tests
{
    public class WeatherForecastServiceTests
    {
        private Mock<IWeatherRepository> _weatherRepositoryMock;

        public WeatherForecastServiceTests()
        {
            _weatherRepositoryMock = new Mock<IWeatherRepository>();
        }
        public void Create()
        {
            //arrange
            var fixture = new Fixture();
            WeatherForecast weatherForecast = fixture.Create<WeatherForecast>();
            
            
            //act

            //assert
        }

        public void Read()
        {
            
        }

        public void Update()
        {
            
        }

        public void Delete()
        {
            
        }
    }
}