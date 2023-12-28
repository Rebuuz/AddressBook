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
            Console.WriteLine("### ADDRESSBOK ###");
            Console.WriteLine();
            Console.WriteLine("MENU");
            Console.WriteLine();
            Console.WriteLine("1. Öppna Addressboken.");
            Console.WriteLine("2. Lägg till ny kontakt.");
            Console.WriteLine("3. Sök på kontakt.");
            Console.WriteLine("4. Avsluta.");

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
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Felaktigt val, välj något av ovanstående istället.");
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
        Console.WriteLine("Alla kontakter i adressboken:");
        Console.WriteLine();

        var contacts = _contactService.GetContactsFromList();

        int index = 1;

        foreach (var contact in contacts)
        {
            Console.WriteLine($"  {index}. {contact.FirstName} {contact.LastName}");
            index++;
        }

        Console.WriteLine();
        Console.Write("Ange siffran på kontakten du vill öppna: ");

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

            Console.WriteLine("Ogiltigt val. Vänligen ange ett giltigt nummer för att välja en kontakt.");
        }
        else
        {
            Console.WriteLine("Ogiltig inmatning. Ange ett nummer.");
        }

        Console.ReadKey();
    }

    /// <summary>
    /// Visar detaljerna på vald kontakt i listan. En meny finns för att antingen radera kontakten eller ändra information i kontakten.
    /// </summary>
    public void DisplayContactDetails(Contact selectedContact)
    {
        Console.Clear();
        Console.WriteLine("Kontaktinformation:");
        Console.WriteLine();
        Console.WriteLine($"Namn:       {selectedContact.FirstName} {selectedContact.LastName}");
        Console.WriteLine($"Email:      {selectedContact.Email}");
        Console.WriteLine($"Telefon:    {selectedContact.Number}");
        Console.WriteLine($"Address:    {selectedContact.Address}, {selectedContact.Region}, {selectedContact.City}");
        Console.WriteLine();

        Console.WriteLine("1. Ändra kontaktinformation");
        Console.WriteLine("2. Radera kontakt.");
        Console.WriteLine();
        Console.Write("Välj en av ovanstående siffor: ");
        Console.WriteLine("Klicka två gånger på enter för att komma tillbaka till menyn.");

        var options = Console.ReadLine();

        switch (options) 
        {
            case "1":
                ///Hade velat lägga till att man ska kunna välja vilken information som ska ändras i listan istället för att behöva skriva in allt igen
                Console.Write("Förnamn: ");
                string newFirstName = Console.ReadLine()!;
                Console.Write("Efternamn: ");
                string newLastName = Console.ReadLine()!;
                Console.Write("Email: ");
                string newEmail = Console.ReadLine()!;
                Console.Write("Telefonnummer: ");
                string newNumber = Console.ReadLine()!;
                Console.Write("Address: ");
                string newAddress = Console.ReadLine()!;
                Console.Write("Stad: ");
                string newCity = Console.ReadLine()!;
                Console.Write("Postnummer: ");
                string newRegion = Console.ReadLine()!;

                _contactService.UpdateContactInformation(selectedContact, newFirstName, newLastName, newEmail, newNumber, newAddress, newCity, newRegion);
                Console.WriteLine();
                Console.WriteLine("Kontakten är uppdaterad.");

                break;
            case "2":
                _contactService.DeleteContactsFromList(selectedContact);
                Console.ReadLine();
                break;
            default:
                Console.WriteLine("Välj en av ovanstående siffror.");
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
        Console.Write("Förnamn: ");
        contact.FirstName = Console.ReadLine()!;
        Console.Write("Efternamn: ");
        contact.LastName = Console.ReadLine()!;
        Console.Write("Email: ");
        contact.Email = Console.ReadLine()!;
        Console.Write("Telefonnummer: ");
        contact.Number = Console.ReadLine()!;
        Console.Write("Address: ");
        contact.Address = Console.ReadLine()!;
        Console.Write("Stad: ");
        contact.City = Console.ReadLine()!;
        Console.Write("Postnummer: ");
        contact.Region = Console.ReadLine()!;   

        _contactService.AddContactToList(contact);

        Console.WriteLine();
        Console.WriteLine("Kontakten är tillagd.");
    }



}
