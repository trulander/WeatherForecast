using Microsoft.EntityFrameworkCore;
using WebApplication4.DataLayer.Entities;

namespace DataAccess.Contexts
{
    public class WeatherContextDb : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        
        public WeatherContextDb(DbContextOptions<WeatherContextDb> options) : base(options)
        {
             
        }

    }
}