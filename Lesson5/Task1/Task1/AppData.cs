using Microsoft.VisualBasic;

namespace Task1;

public class AppData
{
    // public Fields
    public List<DirectoryInfo> Folders { get; private set; }
    public List<FileInfo> Files { get; private set; }
    public string Path
    {
        get { return _path; }
        set
        {
            // if Path Exist
            if (Directory.Exists(value))
            {
                // Setting value
                _path = value;

                // Creating new List
                Folders = new List<DirectoryInfo>();
                Files = new List<FileInfo>();

                // Filling 'Folders' Folders from Directory Path
                foreach (var folderPath in Directory.GetDirectories(value))
                    Folders.Add(new DirectoryInfo(folderPath));

                // Filling 'Files' with Files from Directory Path
                foreach (var filePath in Directory.GetFiles(value))
                    Files.Add(new FileInfo(filePath));

            }
            // if Not Exist
            else
            {
                _path = "Error Directory";
                Folders = new List<DirectoryInfo>();
                Files = new List<FileInfo>();
            }

            // Generating Data for Table in Menu
            _app.Menu.GenerateTableLines();
        }
    }

    // Private Fields
    private string _path;
    private App _app;

    public AppData(App app) 
    { 
        _app = app;
    }
}
