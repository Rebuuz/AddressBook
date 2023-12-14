using AddressBook.Models;

namespace AddressBook.Interfaces
{
    public interface IContactService
    {
        void AddContactToList(Contact contact);
        void DeleteContactsFromList(Contact contact);
        List<Contact> GetContactsFromList();
        void UpdateContactInformation(Contact existingContact, string newFirstName, string newLastName, string newEmail, string newNumber, string newAddress, string newCity, string newRegion);
    }
}