﻿
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

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="sp"></param>
    /// <param name="contactService"></param>
    public ContactUpdateViewModel(IServiceProvider sp, ContactService contactService)
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
    private void Update()
    {
        _contactService.Update(Contact);

        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<ContactDetailViewModel>();

    }

    [RelayCommand]
    private void NavigateToDetail(Contact contact)
    {
        _contactService.CurrentContact = contact;

        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<ContactDetailViewModel>();
    }

}
