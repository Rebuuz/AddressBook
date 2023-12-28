using System.Diagnostics;
using System.Globalization;

namespace AddressBook.Shared.Services;

/// <summary>
/// Ett interface till klassen med information.
/// En funktion för att spara till en fil och en funktion för att kunna hämta från filen. 
/// </summary>
public interface IFileService
{
    bool SaveContactToFile(string contact);
    string GetContactsFromFile();
}
public class FileService(string filePath) : IFileService
{
    private readonly string _filePath = filePath;

    public bool SaveContactToFile(string contact)
    {
        try
        {
            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(contact);
            }
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;

    }
    public string GetContactsFromFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                using (var sr = new StreamReader(_filePath))
                {
                    return sr.ReadToEnd();
                }
            }

        }
        catch (Exception ex)
        { Debug.WriteLine(ex.Message); }
        return null!;
    }


}

