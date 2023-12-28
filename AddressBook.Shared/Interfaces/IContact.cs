namespace AddressBook.Interfaces
{
    /// <summary>
    /// Interface klassen contact för att underlätta när det kommer till testerna
    /// </summary>
    public interface IContact
    {
        string Address { get; set; }
        string City { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Number { get; set; }
        string Region { get; set; }
    }
}