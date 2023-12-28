using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Services;
using AddressBookApp.ViewModels;
using AddressBookApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace AddressBookApp;

/// <summary>
/// Dependency injection
/// </summary>
public partial class App : Application
{
    private IHost? _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<ContactService>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewModel>();
                services.AddTransient<ContactListViewModel>();
                services.AddTransient<ContactListView>();
                services.AddTransient<ContactAddViewModel>();
                services.AddTransient<ContactAddView>();
                services.AddTransient<MainMenuViewModel>();
                services.AddTransient<MainMenuView>();
                services.AddTransient<ContactUpdateViewModel>();
                services.AddTransient<ContactUpdateView>();
                services.AddTransient<ContactDetailViewModel>();
                services.AddTransient<ContactDetailView>();
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host!.Start();

        var mainWindow = _host!.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();  
    }
}
