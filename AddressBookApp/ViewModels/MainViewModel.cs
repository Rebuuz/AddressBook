using AddressBook.Shared.Models;
using AddressBook.Shared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace AddressBookApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject? _currentViewModel;


    private readonly IServiceProvider _sp;
    

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="sp"></param>
    public MainViewModel(IServiceProvider sp)
    {
        _sp = sp;
        CurrentViewModel = _sp.GetRequiredService<MainMenuViewModel>();

    }
}
