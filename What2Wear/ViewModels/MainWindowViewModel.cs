using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using What2Wear.Services;

namespace What2Wear.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string whatToWear = "...";

    [ObservableProperty] 
    private string? nameOfCity;

    [RelayCommand]
    private void Find(ICityFinder cityFinder)
    {
        var coordinates = cityFinder.FindCity(nameOfCity);
    }
}