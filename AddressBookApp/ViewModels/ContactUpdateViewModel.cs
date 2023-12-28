
using AddressBook.Shared.Services;
using AddressBook.Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Security.Cryptography;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBookApp.ViewModels;

public partial class ContactUpdateViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly ContactService _contactService;


    public ContactUpdateViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;

        Contact = _contactService.CurrentContact;
    }

    [ObservableProperty]
    private Contact contact = new();


    [RelayCommand]
    private void UpdateContactInformation()
    {
        _contactService.UpdateContactInformation(contact,
            newFirstName:contact,
            newLastName:contact,
            newEmail:contact,
            newNumber:contact,
            newAddress:contact,
            newCity:contact,
            newRegion:contact);

        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<ContactDetailViewModel>();
    }

}
