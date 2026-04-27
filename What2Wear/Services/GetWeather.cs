using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace What2Wear.Services;

public class GetWeather : IGetWeather
{
    private readonly HttpClient httpClient;

    public GetWeather(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<WeatherResponse?> GetWeatherAsync(double lat, double lon)
    {
        var url =
            $"https://api.open-meteo.com/v1/forecast?" +
            $"latitude={lat}&longitude={lon}" +
            $"&current=temperature_2m,precipitation,wind_speed_10m" +
            $"&timezone=auto";

        try
        {
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<WeatherResponse>(json);

            return data;
        }
        catch
        {
            return null;
        }
    }
}