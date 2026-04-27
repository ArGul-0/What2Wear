using System.Threading.Tasks;

namespace What2Wear.Services;

public interface IGetWeather
{
    public Task<WeatherResponse> GetWeatherAsync(double lat, double lon);
}