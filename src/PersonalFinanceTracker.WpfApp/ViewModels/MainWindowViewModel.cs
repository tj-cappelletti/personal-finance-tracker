using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Ui.Controls;

namespace PersonalFinanceTracker.WpfApp.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]private string _applicationTitle = string.Empty;

    private bool _isInitialized;

    [ObservableProperty]private ObservableCollection<object> _navigationFooter = [];

    [ObservableProperty]private ObservableCollection<object> _navigationItems = [];

    [ObservableProperty]private ObservableCollection<MenuItem> _trayMenuItems = [];

    public MainWindowViewModel()
    {
        if (!_isInitialized)
            InitializeViewModel();
    }

    private void InitializeViewModel()
    {
        ApplicationTitle = "WPF UI - MVVM Demo";

        NavigationItems = [];

        NavigationFooter = [];

        TrayMenuItems = [new MenuItem { Header = "Home", Tag = "tray_home" }];

        _isInitialized = true;
    }
}
