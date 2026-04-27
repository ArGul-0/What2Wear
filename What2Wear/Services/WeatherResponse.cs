using Newtonsoft.Json;
using What2Wear.Services;

public class WeatherResponse
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    [JsonProperty("current")]
    public CurrentWeather Current { get; set; }
}