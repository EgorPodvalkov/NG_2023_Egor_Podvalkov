using Task3.Interfaces;

namespace Task3;

public class FileSystem : IFileSystem
{
    private Checker _checker = new Checker();

    public void CheckFile(string filename)
    {
        _checker.CheckRole();
        Console.WriteLine("Checking...");
    }

    public void CopyFile(string filename)
    {
        _checker.CheckRole();
        Console.WriteLine("Copying...");
    }

    public void DeleteFile(string filename)
    {
        _checker.CheckRole();
        Console.WriteLine("Deleting...");
    }

    public void DownloadFile(string filename)
    {
        _checker.CheckRole();
        Console.WriteLine("Downloading...");
    }

    public void SaveToFile(string filename)
    {
        _checker.CheckRole();
        Console.WriteLine("Saving...");
    }
}
