using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using What2Wear.Services;
using What2Wear.ViewModels;
using What2Wear.Views;

namespace What2Wear;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; set; }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();
        
        ConfigureServices(services);

        ServiceProvider = services.BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    private void ConfigureServices(IServiceCollection services)
    {
        // ViewModels

        // Windows

        // Services
        services.AddScoped<ICityFinder, CityFinder>();
        services.AddScoped<IGetWeather, GetWeather>();
    }
}