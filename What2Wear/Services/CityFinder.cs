using System.Linq;
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
        var url = $"https://geocoding-api.open-meteo.com/v1/search?name={city}";
        
        var json = await httpClient.GetStringAsync(url);
        var data = JsonConvert.DeserializeObject<GeoResponse>(json);

        return data?.Results?.FirstOrDefault();
    }
}