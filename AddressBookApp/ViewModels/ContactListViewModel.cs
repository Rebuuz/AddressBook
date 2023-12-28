using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace AddressBookApp.ViewModels;

/// <summary>
/// Using ContactService instead of IContactService because the latter didn't seem to work, don't know why that is
/// </summary>
public partial class ContactListViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly ContactService _contactService;

   

    public ContactListViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;

        Contacts = new ObservableCollection<Contact>(_contactService.GetContactsFromList());
    }

    [ObservableProperty]
    private ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>();

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

    [RelayCommand]
    private void NavigateToUpdate()
    {
        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<ContactUpdateViewModel>();
    }

    [RelayCommand]
    private void NavigateToDetail(Contact contact)
    {
        _contactService.CurrentContact = contact;

        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<ContactDetailViewModel>();
    }
}
