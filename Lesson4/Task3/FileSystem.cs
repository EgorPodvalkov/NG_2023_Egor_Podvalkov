using Task3.Interfaces;

namespace Task3;

public class FileSystem : IFileSystem
{
    public void CheckFile(string filename)
    {
        new Checker().CheckRole();
        Console.WriteLine("Checking...");
    }

    public void CopyFile(string filename)
    {
        new Checker().CheckRole();
        Console.WriteLine("Copying...");
    }

    public void DeleteFile(string filename)
    {
        new Checker().CheckRole();
        Console.WriteLine("Deleting...");
    }

    public void DownloadFile(string filename)
    {
        new Checker().CheckRole();
        Console.WriteLine("Downloading...");
    }

    public void SaveToFile(string filename)
    {
        new Checker().CheckRole();
        Console.WriteLine("Saving...");
    }
}
