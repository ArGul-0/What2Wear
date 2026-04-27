using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using What2Wear.Services;

namespace What2Wear.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly ICityFinder cityFinder;
    private readonly IGetWeather weatherService;

    public MainWindowViewModel(ICityFinder cityFinder, IGetWeather weatherService)
    {
        this.cityFinder = cityFinder;
        this.weatherService = weatherService;
    }
    
    [ObservableProperty]
    private string whatToWear = "...";

    [ObservableProperty] 
    private string? nameOfCity;

    [RelayCommand]
    private async Task Find()
    {
        if (string.IsNullOrWhiteSpace(nameOfCity))
        {
            WhatToWear = "Please enter a city name";
            return;
        }
        
        WhatToWear = "Searching City...";
        
        var city = await cityFinder.FindCityAsync(nameOfCity);

        if (city is null)
        {
            WhatToWear = "City not found";
            return;
        }

        WhatToWear = "Loading Weather...";
        
        var weather = await weatherService.GetWeatherAsync(city.Latitude, city.Longitude);
        
        if (weather == null)
        {
            WhatToWear = "Failed to get weather";
            return;
        }
        
        WhatToWear = BuildAdvice(weather);
    }
    
    private string BuildAdvice(WeatherResponse weather)
    {
        var temp = weather.Current.Temperature;
        var rain = weather.Current.Precipitation;

        if (rain > 0.3)
            return "☔ Take A Rain Coat";

        if (temp < 0)
            return "🧥 Very Cold, Take A Jacket";

        if (temp < 10)
            return "🧥 Cold, Take A Lightweight Jacket";

        if (temp < 20)
            return "👕 Warm, Take A Sweater";

        return "☀️ Very Warm, Take A T-Shirt";
    }
}