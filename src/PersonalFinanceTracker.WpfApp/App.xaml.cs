using System;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceTracker.WpfApp.Services;
using PersonalFinanceTracker.WpfApp.ViewModels;
using PersonalFinanceTracker.WpfApp.Views;
using Wpf.Ui;

namespace PersonalFinanceTracker.WpfApp;

public partial class App
{
    private readonly IServiceProvider _serviceProvider = ConfigureServices();

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IPageService, PageService>();

        services.AddSingleton<IThemeService, ThemeService>();
        services.AddSingleton<ITaskBarService, TaskBarService>();
        services.AddSingleton<INavigationService, NavigationService>();

        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();

        return services.BuildServiceProvider();
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) { }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainWindow = _serviceProvider.GetService<MainWindow>();

        mainWindow?.Show();
    }
}
