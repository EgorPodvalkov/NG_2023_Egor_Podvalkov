using Task3.Interfaces;

namespace Task3;

public class FileWorker : IFileWorker
{
    private Checker _checker = new Checker();
    public void GetDataFromFile(string filename)
    {
        _checker.CheckRole();
        Console.WriteLine("Getting...");
    }

    public string ReadFromFile(string filename)
    {
        _checker.CheckRole();
        return "Reading...";
    }

    public void WriteToFile(string filename)
    {
        _checker.CheckRole();
        Console.WriteLine("Writting...");
    }
}
