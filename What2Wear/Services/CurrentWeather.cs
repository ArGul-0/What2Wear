using Newtonsoft.Json;

namespace What2Wear.Services;

public class CurrentWeather
{
    [JsonProperty("temperature_2m")]
    public double Temperature { get; set; }

    [JsonProperty("precipitation")]
    public double Precipitation { get; set; }

    [JsonProperty("wind_speed_10m")]
    public double WindSpeed { get; set; }
}