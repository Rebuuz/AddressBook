using AddressBook.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AddressBook.Services;

public class ContactService
{
    //Sparar i filerna
    private readonly FileService _fileService = new FileService(@"C:\EC\DotNet\contacts.json");

    //Skapar en tom lista
    private List<Contact> _contacts = [];

    //Lägga till kontaker i listan
    public void AddContactToList(Contact contact)
    {
        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);
                _fileService.SaveContactToFile(JsonConvert.SerializeObject(_contacts));
                Console.WriteLine("Kontakten är tillagd i addressboken.");
            }
        }
        
        catch (Exception ex)
        {
            Debug.WriteLine($"Fel vid tillägg av kontakt: {ex.Message}");
        }
    }

    //Hämtar listan

    public IEnumerable<Contact> GetContactsFromList()
    {
        try
        {
            var contacts = _fileService.GetContactsFromFile();
            Debug.WriteLine($"Innehåll från filen: {contacts}");

            if (!string.IsNullOrEmpty(contacts))
            {
                var deserializedContacts = JsonConvert.DeserializeObject<List<Contact>>(contacts);
                if (deserializedContacts != null)
                {
                    _contacts.Clear(); // Rensa befintliga kontakter i _contacts-listan
                    _contacts.AddRange(deserializedContacts); // Lägg till de deserialiserade kontakterna i _contacts
                    Debug.WriteLine("Deserialisering lyckades.");
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Det gick inte att hämta listan: {ex.Message}");
        }

        return _contacts;
    }
}



