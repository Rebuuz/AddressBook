

using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBookApp.ViewModels;

public partial class ContactDetailViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly ContactService _contactService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="sp"></param>
    /// <param name="contactService"></param>
    public ContactDetailViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;

        Contact = _contactService.CurrentContact;
    }

    [ObservableProperty]
    private Contact contact = new();


    /// <summary>
    /// commands/functions
    /// </summary>
    [RelayCommand]
    private void NavigateToUpdate()
    {
        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<ContactUpdateViewModel>();
    }

    [RelayCommand]
    private void NavigateBack()
    {
        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<MainMenuViewModel>();
    }

    [RelayCommand]
    private void NavigateToDelete()
    {
        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<ContactDeleteViewModel>();
    }
}
