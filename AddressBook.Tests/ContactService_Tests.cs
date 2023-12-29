using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;


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
        Contact newContact = new Contact("Test_FirstName", "Test_LastName", "Test_Email", "Test_Number", "Test_Address", "Test_City", "Test_Region");

        ///Act
        contactService.AddContactToList(newContact);

        ///Assert
        var result = contactService.GetContactsFromList();
        Assert.NotNull(result);
    }


    [Fact]
    public void GetContactsFromListShould_GetAllContactsInContactList_ThenReturnListOfContacts()
    {
        ///Arrange
        IContactService contactService = new ContactService();
        Contact newContact = new Contact("Test_FirstName", "Test_LastName", "Test_Email", "Test_Number", "Test_Address", "Test_City", "Test_Region");

        ///Act
        List<Contact> result = contactService.GetContactsFromList();

        ///Assert
        Assert.NotNull(result);
        Contact returned_contact = result.FirstOrDefault()!;
        Assert.NotNull(returned_contact);
        Assert.Equal(newContact.FirstName, returned_contact.FirstName);
    }
}
