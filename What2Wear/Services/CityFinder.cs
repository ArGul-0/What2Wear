using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using What2Wear.Models;

namespace What2Wear.Services;

public class CityFinder : ICityFinder
{
    private readonly HttpClient httpClient;

    public CityFinder(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<GeoResult?> FindCityAsync(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
            return null;

        var encodedCity = WebUtility.UrlEncode(city);

        var url = $"https://geocoding-api.open-meteo.com/v1/search?name={encodedCity}&count=1";

        try
        {
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<GeoResponse>(json);

            return data?.Results?.FirstOrDefault();
        }
        catch
        {
            return null;
        }
    }
}