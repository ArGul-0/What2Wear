using CommunityToolkit.Mvvm.ComponentModel;

namespace What2Wear.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string whatToWear = "...";
}