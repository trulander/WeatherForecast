using AutoFixture;
using Xunit;
using Moq;
using WebApplication4.Controllers.Models;
using WebApplication4.Core;
using WebApplication4.DataLayer.Contexts;
using WebApplication4.DataLayer.Repositories;

namespace WebApplication4.DataLayer.Tests
{
    public class WeatherRepositoryTests
    {
        private Mock<WeatherContextDb> _weatherContextDbMockMock;
        private WeatherRepository _weatherRepository;

        public WeatherRepositoryTests()
        {
            _weatherContextDbMockMock = new Mock<WeatherContextDb>();
            _weatherRepository = new WeatherRepository(_weatherContextDbMockMock.Object);
        }
        
        public void Create()
        {
            //arrange
            var fixture = new Fixture();
            WeatherForecast weatherForecast = fixture.Create<WeatherForecast>();

            
            //act
            var id = _weatherRepository.Create(weatherForecast);

            //assert
            Assert.NotNull(id);
            _weatherContextDbMockMock.Verify(x=>x.WeatherForecasts, Times.Once);

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