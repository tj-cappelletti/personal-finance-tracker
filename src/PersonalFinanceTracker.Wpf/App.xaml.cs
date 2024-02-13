using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace PersonalFinanceTracker.Wpf;

public partial class App
{
    private readonly IServiceProvider _serviceProvider = ConfigureServices();

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddScoped<MainWindow>();

        return services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainWindow = _serviceProvider.GetService<MainWindow>();
        mainWindow?.Show();
    }
}
