using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml.Serialization;

namespace AddressBook.Shared.Services;


public class ContactService : IContactService
{
    /// <summary>
    /// Sparar till en json-fil på datorn. Filen läggs inne i de separata mapparna för AddresBook och AddressBook.Tests.
    /// </summary>
    private readonly FileService _fileService = new FileService(Path.Combine(Environment.CurrentDirectory, @"..\..\..\contacts.json"));



    /// <summary>
    /// En tom lista
    /// </summary>
    public List<Contact> _contacts = [];

    public Contact CurrentContact { get; set; } = null!;

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

                Console.WriteLine("Contact added successfully.");
                Console.WriteLine();
                Thread.Sleep(2000);
            }
        }

        catch (Exception ex)
        {
            Debug.WriteLine($"Error while adding contact:  {ex.Message}");
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
        Console.WriteLine($"Confirm you want to delete {contact.FirstName} {contact.LastName} by email: ");
        string deleteByEmail = Console.ReadLine()!;

        try
        {
            if (string.Equals(deleteByEmail, contact.Email, StringComparison.OrdinalIgnoreCase))
            {
                _contacts.Remove(contact);
                _fileService.SaveContactToFile(JsonConvert.SerializeObject(_contacts));

                Console.WriteLine();
                Console.WriteLine("Contact deletet successfully. Please wait.");
                Console.WriteLine();
                Thread.Sleep(2000);
            }
        }

        catch (Exception ex)
        {
            Debug.WriteLine($"Error while deleting contact: {ex.Message}");
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

    /// <summary>
    /// Another Update for the wpf-app, because I couldn't make the above one work, so this one is the only one used in the wpf-project
    /// </summary>
    /// <param name="contact"></param>
    public void Update(Contact contact)
    {
        var contacts = _contacts.FirstOrDefault(x => x.Email == contact.Email);
        if(contacts != null)
        {
            contacts = contact;

            _fileService.SaveContactToFile(JsonConvert.SerializeObject(_contacts));
        }
    }

    ///Another Delete for my wpf-app so I don't have to use the one I have above for my console-app
   public void RemoveWPF(string emailConfirm)
    {
        try
        {
            if (string.Equals(emailConfirm, CurrentContact.Email, StringComparison.OrdinalIgnoreCase))
            {
                _contacts.Remove(CurrentContact);
                _fileService.SaveContactToFile(JsonConvert.SerializeObject(_contacts));

            }
            else
            {
                throw new Exception("Email doesn't match, contact was not deleted.");
            }
        }

        catch (Exception ex)
        {
            Debug.WriteLine($"Error while deleting contact: {ex.Message}");
        }
    }

}

