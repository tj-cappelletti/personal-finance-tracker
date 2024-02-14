using System;
using System.Windows;
using PersonalFinanceTracker.WpfApp.ViewModels;
using Wpf.Ui;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace PersonalFinanceTracker.WpfApp.Views;

public partial class MainWindow : INavigationWindow
{
    public MainWindowViewModel ViewModel { get; }

    public MainWindow(
        MainWindowViewModel viewModel,
        IPageService pageService,
        INavigationService navigationService)
    {
        DataContext = this;

        ViewModel = viewModel;

        SystemThemeWatcher.Watch(this);

        InitializeComponent();

        SetPageService(pageService);

        navigationService.SetNavigationControl(NavigationView);
    }

    public void CloseWindow()
    {
        Close();
    }

    public INavigationView GetNavigation()
    {
        return NavigationView;
    }

    public bool Navigate(Type pageType)
    {
        return NavigationView.Navigate(pageType);
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);

        Application.Current.Shutdown();
    }

    public void SetPageService(IPageService pageService)
    {
        NavigationView.SetPageService(pageService);
    }

    public void SetServiceProvider(IServiceProvider serviceProvider)
    {
        throw new NotImplementedException();
    }

    public void ShowWindow()
    {
        Show();
    }
}
