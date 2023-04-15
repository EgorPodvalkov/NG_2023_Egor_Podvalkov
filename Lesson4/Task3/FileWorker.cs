using Task3.Interfaces;

namespace Task3;

public class FileWorker : IFileWorker
{
    public void GetDataFromFile(string filename)
    {
        new Checker().CheckRole();
        Console.WriteLine("Getting...");
    }

    public string ReadFromFile(string filename)
    {
        new Checker().CheckRole();
        return "Reading...";
    }

    public void WriteToFile(string filename)
    {
        new Checker().CheckRole();
        Console.WriteLine("Writting...");
    }
}
