using System.Diagnostics;
using System.Globalization;

namespace AddressBook.Services;

//ett interface till min file-service för att hantera informationen
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
                var fileContent = File.ReadAllText(_filePath);
                Debug.WriteLine($"Filen innehåller: {fileContent}");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Fel vid läsning av filen: {ex.Message}");
        }
        return null!;
        
    }

    
}
