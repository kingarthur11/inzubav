namespace jvconsult
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
        
  //"ConnectionStrings": {
   // "WebApiDatabase": "Server=.\\SQLExpress;Database=movie_db;Trusted_Connection=true;TrustServerCertificate=true"
  //}
    }
}
