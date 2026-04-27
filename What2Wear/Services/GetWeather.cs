using System.Threading.Tasks;

namespace What2Wear.Services;

public class GetWeather : IGetWeather
{
    public async Task<WeatherResponse> GetWeatherAsync(double lat, double lon)
    {
        return await Task.FromResult(new WeatherResponse
            {
                Latitude = lat,
                Longitude = lon,
                Current = new CurrentWeather
                {
                    Temperature = 20,
                    Precipitation = 0.5,
                    WindSpeed = 10,
                }
            }
        );
    }
}