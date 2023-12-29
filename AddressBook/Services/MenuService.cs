using AddressBook.Shared.Models;
using AddressBook.Shared.Services;

namespace AddressBook.Services;

public class MenuService
{
    private readonly ContactService _contactService = new ContactService();

    /// <summary>
    /// Main meny för programmet
    /// </summary>
    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("### ADDRESSBOOK ###");
            Console.WriteLine();
            Console.WriteLine("MENU");
            Console.WriteLine();
            Console.WriteLine("1. Open AddressBook.");
            Console.WriteLine("2. Add New Contact.");
            Console.WriteLine("3. Exit.");

            var option = Console.ReadLine();    

            switch (option)
            {
                case "1":
                    ShowAllMenu();
                    break;
                case "2":
                    ShowAddMenu();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option, please enter one of the options above.");
                    break;
            }
        }
    }

    /// <summary>
    /// Visa alla kontakter. Foreach loopen skriver ut för- och efternamn i en lista. Alla kontakter visas i en numrerad lista med start från 1.
    /// Med hjälp av indexet kan man sen välja en viss kontakt för att läsa mer detaljerad information. 
    /// </summary>
    public void ShowAllMenu()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("~ All Contacts ~");
        Console.WriteLine();

        var contacts = _contactService.GetContactsFromList();

        ///Shows contacts listed with a number so you can then later choose which contact to read more details about.
        int index = 1;

        foreach (var contact in contacts)
        {
            Console.WriteLine($"  {index}. {contact.FirstName} {contact.LastName, -10} <{contact.Email}>");
            index++;
        }

        Console.WriteLine("_______________________________________________________________");
        Console.WriteLine();
        Console.WriteLine("Click Enter to go back.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Choose the number corresponding to the contact you want to open: ");

        int selectedIndex;
        bool isValidInput = int.TryParse(Console.ReadLine(), out selectedIndex);

        if (isValidInput)
        {
            index = 1;
            foreach (var contact in contacts)
            {
                if (index == selectedIndex)
                {
                    DisplayContactDetails(contact);
                    return;
                }
                index++;
            }
        }
        else
        {
            Console.WriteLine("Choose one of the options or press Enter again to exit.");
        }

        Console.ReadKey();
 
    }

    /// <summary>
    /// Visar detaljerna på vald kontakt i listan. En meny finns för att antingen radera kontakten eller ändra information i kontakten.
    /// </summary>
    public void DisplayContactDetails(Contact selectedContact)
    {
        Console.Clear();
        Console.WriteLine("Contact Details");
        Console.WriteLine();
        Console.WriteLine($"Name:       {selectedContact.FirstName} {selectedContact.LastName}");
        Console.WriteLine($"Email:      {selectedContact.Email}");
        Console.WriteLine($"Phone:      {selectedContact.Number}");
        Console.WriteLine($"Address:    {selectedContact.Address}, {selectedContact.Region}, {selectedContact.City}");
        Console.WriteLine();

        Console.WriteLine("1. Update contact information.");
        Console.WriteLine("2. Delete contact.");
        Console.WriteLine();
        Console.Write("Choose one of the options above: ");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Click twice on any key to go back.");
        Console.WriteLine();

        var options = Console.ReadLine();

        switch (options) 
        {
            case "1":
                ///Hade velat lägga till att man ska kunna välja vilken information som ska ändras i listan istället för att behöva skriva in allt igen
                Console.Write("First name: ");
                string newFirstName = Console.ReadLine()!;
                Console.Write("Last name: ");
                string newLastName = Console.ReadLine()!;
                Console.Write("Email: ");
                string newEmail = Console.ReadLine()!;
                Console.Write("Phone number: ");
                string newNumber = Console.ReadLine()!;
                Console.Write("Address: ");
                string newAddress = Console.ReadLine()!;
                Console.Write("City: ");
                string newCity = Console.ReadLine()!;
                Console.Write("Postal code: ");
                string newRegion = Console.ReadLine()!;

                _contactService.UpdateContactInformation(selectedContact, newFirstName, newLastName, newEmail, newNumber, newAddress, newCity, newRegion);
                Console.WriteLine();
                Console.WriteLine("Contact updated successfully.");

                break;
            case "2":
                _contactService.DeleteContactsFromList(selectedContact);
                Console.ReadLine();
                break;
            default:
                Console.WriteLine("Choose on of the options above.");
                Console.ReadLine();    
                break;
        }
    }


    /// <summary>
    /// I denna "meny" lägger man till all information om kontakten.
    /// </summary>
    public void ShowAddMenu()
    {
        var contact = new Contact("firstname", "lastname", "email", "number", "address", "city", "region");

        Console.Clear();
        Console.Write("First name: ");
        contact.FirstName = Console.ReadLine()!;
        Console.Write("Last name: ");
        contact.LastName = Console.ReadLine()!;
        Console.Write("Email: ");
        contact.Email = Console.ReadLine()!;
        Console.Write("Phone number: ");
        contact.Number = Console.ReadLine()!;
        Console.Write("Address: ");
        contact.Address = Console.ReadLine()!;
        Console.Write("City: ");
        contact.City = Console.ReadLine()!;
        Console.Write("Postal Code: ");
        contact.Region = Console.ReadLine()!;   

        _contactService.AddContactToList(contact);

        Console.WriteLine();
        Console.WriteLine("Contact added successfully.");
    }



}
