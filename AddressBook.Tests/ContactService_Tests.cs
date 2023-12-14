using AddressBook.Interfaces;
using AddressBook.Models;
using AddressBook.Services;


namespace AddressBook.Tests;

/// <summary>
/// Väljer att ha public för att annars kommer jag inte åt filerna. 
/// </summary>
public class ContactService_Tests
{
    ///Mitt test
    [Fact]
    public void AddToListShould_AddOneContactToContactList_ThenReturnTrue()
    {
        ///Arrange
        IContactService contactService = new ContactService();
        Contact newContact = new Contact("FirstName", "LastName", "Email", "Number", "Address", "City", "Region");

        ///Act
        contactService.AddContactToList(newContact);

        ///Assert
        var result = contactService.GetContactsFromList();
        Assert.NotNull(result);
    }
}
