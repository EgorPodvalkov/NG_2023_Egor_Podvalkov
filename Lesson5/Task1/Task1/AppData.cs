
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
            // Creating new Lists
            Folders = new List<DirectoryInfo>();
            Files = new List<FileInfo>();

            // if Path Exist
            if (Directory.Exists(value))
            {
                // Setting value
                _path = value;

                // Filling 'Folders' with Folders from Directory Path
                foreach (var folderPath in Directory.GetDirectories(value))
                    Folders.Add(new DirectoryInfo(folderPath));

                // Filling 'Files' with Files from Directory Path
                foreach (var filePath in Directory.GetFiles(value))
                    Files.Add(new FileInfo(filePath));

            }
            // if Path is Drives List
            else if (value == "Drives")
            {
                // Setting value
                _path = value;

                // Filling 'Folders' with Drives
                foreach (var drive in DriveInfo.GetDrives())
                    Folders.Add(drive.RootDirectory);
            }
            // if Not Exist
            else
                _path = "Error Directory, Press Esc";

            // Generating Data for Table in Menu
            _app.Menu.GenerateTableLines();
        }
    }
    public string BufferPath { get; private set; } = "";
    public string PasteMod { get; set; } = "";
    // Private Fields
    private string _path;
    private App _app;

    public AppData(App app) 
    { 
        _app = app;
    }

    public void SetBufferPath(int index = -1) 
    {
        // Bad Index
        if (index < 0 || index >= Folders.Count + Files.Count)
        {
            BufferPath = "";
            return;
        }

        // if Folder
        if (index < Folders.Count)
        {
            BufferPath = Folders[index].FullName;
            return;
        }

        // if File
        index -= Folders.Count;
        if (index < Files.Count)
            BufferPath = Files[index].FullName;
    }
}
