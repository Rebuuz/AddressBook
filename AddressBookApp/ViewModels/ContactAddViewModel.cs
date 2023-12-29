

using Accessibility;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBookApp.ViewModels;

public partial class ContactAddViewModel : ObservableObject
{
    /// <summary>
    /// Service Provider which makes it possible to move from Add-view to List-view
    /// as well as using contactService
    /// </summary>
    private readonly IServiceProvider _sp;
    private readonly ContactService _contactService;

    /// <summary>
    /// constructor for service provider and contactservice
    /// </summary>
    /// <param name="sp"></param>
    /// <param name="contactService"></param>
    public ContactAddViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;
    }

    [ObservableProperty]
    private Contact contact = new Contact();


    /// <summary>
    /// Commands/functions
    /// </summary>
    [RelayCommand]
    private void AddContactToList()
    {
        _contactService.AddContactToList(contact);

        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }
    
    [RelayCommand]
    private void NavigateToList()
    {
        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }

    [RelayCommand]
    private void NavigateBack()
    {
        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<MainMenuViewModel>();
    }

}
