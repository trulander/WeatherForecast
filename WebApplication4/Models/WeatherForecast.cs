using System;

namespace WebApplication4.Models
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

        public string Summary { get; set; }
        public string Comment { get; set; }

        public WeatherForecast(int id, DateTime date, int temperatureC, string summary, string comment)
        {
            Id = id;
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
            Comment = comment;
        }
    }
}