using AddressBook.Interfaces;

namespace AddressBook.Shared.Models;

public class Contact : IContact
{

    /// <summary>
    /// Props som är nullable
    /// </summary>
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Region { get; set; } = null!;

    ///En tom konstruktor
    public Contact()
    {

    }

    /// <summary>
    /// Konstruktor för klassen som använder sig av nedanstående params utefter ovanstående kod.
    /// </summary>
    /// <param name="firstname"></param>
    /// <param name="lastname"></param>
    /// <param name="email"></param>
    /// <param name="number"></param>
    /// <param name="address"></param>
    /// <param name="city"></param>
    /// <param name="region"></param>
    public Contact(string firstname, string lastname, string email, string number, string address, string city, string region)
    {
        FirstName = firstname;
        LastName = lastname;
        Email = email;
        Number = number;
        Address = address;
        City = city;
        Region = region;
    }
}


