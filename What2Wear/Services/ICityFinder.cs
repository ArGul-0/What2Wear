using System.Threading.Tasks;
using What2Wear.Models;

namespace What2Wear.Services;

public interface ICityFinder
{
    public Task<GeoResult?> FindCityAsync(string city);
}