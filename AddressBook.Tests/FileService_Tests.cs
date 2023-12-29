using AddressBook.Shared.Services;

namespace AddressBook.Tests;

public class FileService_Tests
{
  /// <summary>
  /// Test to check if fileService works properly and puts content into the json-file. 
  /// </summary>

    [Fact]
    public void SaveContactToFileShould_SaveContactToFile_ThenReturnTrue()
    {
        ///Arrange
        string filePath = @"C:\EC\DotNet\AddressBook\AddressBook.Tests\FilePathTest.txt";
        IFileService fileService = new FileService(filePath);
        string content = "Test FileService";

        ///Act
        bool result = fileService.SaveContactToFile(content);


        ///Assert
        Assert.True(result);
    }
}
