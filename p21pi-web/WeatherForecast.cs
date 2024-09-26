namespace p21pi_web
{
    public class WeatherForecast
    {
        private readonly string _secret = "123";
        public WeatherForecast() { }
        public WeatherForecast(string secret) 
        { 
            _secret = secret;
        }
        public static string TestStatic()
        {
            return "test static";
        }
        public string TestInstance()
        {
            return _secret;
        }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}