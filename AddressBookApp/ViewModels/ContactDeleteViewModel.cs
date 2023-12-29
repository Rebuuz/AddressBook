using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace AddressBookApp.ViewModels;

public partial class ContactDeleteViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly ContactService _contactService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="sp"></param>
    /// <param name="contactService"></param>
    public ContactDeleteViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;

        Contact = _contactService.CurrentContact;
    }

    public string emailConfirm { get; set; } = null!;

    [ObservableProperty]
    private Contact contact = new();


    /// <summary>
    /// Commands/ functions
    /// </summary>
    /// <param name="contact"></param>
    [RelayCommand]
    private void Delete(Contact contact)
    {
        _contactService.RemoveWPF(emailConfirm);

        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();

    }

    [RelayCommand]
    private void NavigateBack()
    {
        var mainVewModel = _sp.GetRequiredService<MainViewModel>();
        mainVewModel.CurrentViewModel = _sp.GetRequiredService<ContactDetailViewModel>();
    }
}
