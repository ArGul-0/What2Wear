using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace What2Wear.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string whatToWear = "...";

    [ObservableProperty] 
    private string nameOfCity;

    [RelayCommand]
    private void Find()
    {
        
    }
}