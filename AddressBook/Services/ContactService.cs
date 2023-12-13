using AddressBook.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AddressBook.Services;

public class ContactService
{
    /// <summary>
    /// Sparar till en json-fil på datorn. 
    /// </summary>
    private readonly FileService _fileService = new FileService(Path.Combine(Environment.CurrentDirectory, @"..\..\..\SavedFiles\content.json"));

    /// <summary>
    /// En tom lista
    /// </summary>
    private List<Contact> _contacts = [];

    /// <summary>
    /// Lägger till objekt (kontakter) till listan
    /// </summary>
    public void AddContactToList(Contact contact)
    {
        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);
                _fileService.SaveContactToFile(JsonConvert.SerializeObject(_contacts));
                
                Console.WriteLine("Kontakten är tillagd i addressboken.");
                Console.WriteLine();
                Thread.Sleep(2000);
            }
        }
        
        catch (Exception ex)
        {
            Debug.WriteLine($"Fel vid tillägg av kontakt: {ex.Message}");
        }
    }

    /// <summary>
    /// Hämtar listan med hjälp av List istället för IEnumerable så att man kan ändra innehållet i listan, 
    /// istället för att den ska vara readonly.
    /// </summary>

    public List<Contact> GetContactsFromList()
    {
        List<Contact> contacts = new List<Contact>();

        try
        {
            var content = _fileService.GetContactsFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"{ex.Message}");
        }
        return _contacts;
    }
    /// <summary>
    /// Funktionen för att kunna radera en kontakt från listan. Funktionen använder sig av fileservice för att komma åt det sparade innehållet.
    /// </summary>
    public void DeleteContactsFromList(Contact contact)
    {
        Console.WriteLine($"Bekräfta att du vill radera {contact.FirstName} {contact.LastName} genom att ange epost-adressen: ");
        string deleteByEmail = Console.ReadLine()!;

        try
        {
            if (string.Equals(deleteByEmail, contact.Email, StringComparison.OrdinalIgnoreCase))
            {
                _contacts.Remove(contact);
                _fileService.SaveContactToFile(JsonConvert.SerializeObject(_contacts));

                Console.WriteLine();
                Console.WriteLine("Kontakten är nu borttagen.");
                Console.WriteLine();
                Thread.Sleep(2000);
            }
        }

        catch (Exception ex)
        {
            Debug.WriteLine($"Fel vid radering av kontakt: {ex.Message}");
        }
    }

    /// <summary>
    /// Funktionalitet för att kunna ändra informationen på ett element i listan.
    /// </summary>
    public void UpdateContactInformation(Contact existingContact, string newFirstName, string newLastName, string newEmail, string newNumber, string newAddress, string newCity, string newRegion)
    {
        existingContact.FirstName = newFirstName;
        existingContact.LastName = newLastName;
        existingContact.Email = newEmail;   
        existingContact.Number = newNumber;
        existingContact.Address = newAddress;
        existingContact.City = newCity;
        existingContact.Region = newRegion;

       _fileService.SaveContactToFile(JsonConvert.SerializeObject(_contacts));

    }


}



