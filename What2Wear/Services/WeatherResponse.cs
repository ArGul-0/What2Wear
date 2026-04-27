namespace What2Wear.Services;

public class WeatherResponse
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public CurrentWeather Current { get; set; }
}