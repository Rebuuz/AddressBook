namespace AddressBook.Models;

public class Contact
{

    //Nullable props
    public string FirstName { get; set; } = null!;
    public string LastName { get; set;} = null!;
    public string Email { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Region { get; set; } = null!;

    //Konstruktor
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


