using AddressBook.Models;

namespace AddressBook.Services;

public class MenuService
{
    private readonly ContactService _contactService = new ContactService();

    //Main meny för programmet
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
                    ShowAll();
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

    //Visa alla kontakter
    public void ShowAll()
    {
        var contacts = _contactService.GetContactsFromList();

        foreach (var contact in contacts) 
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName} {contact.Email} {contact.Number} {contact.Address}");
        }

    }

    //Lägg till Meny
    public void ShowAddMenu()
    {
        var contact = new Contact("firstname", "lastname", "email", "number", "address");

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

        _contactService.AddContactToList(contact);
    }
}
