

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBookApp.ViewModels;

public partial class MainMenuViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
 

    public MainMenuViewModel(IServiceProvider sp)
    {
        _sp = sp;
 
    }

    [RelayCommand]
    private void NavigateToList()
    {
        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }

    [RelayCommand]
    private void NavigateToAdd()
    {
        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<ContactAddViewModel>();
    }

    [RelayCommand]
    private void NavigateBack()
    {
        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<MainMenuViewModel>();
    }
}
