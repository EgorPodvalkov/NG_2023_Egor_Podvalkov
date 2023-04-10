using static System.Net.Mime.MediaTypeNames;

namespace Task1;

public class App
{
    // Public Fields
    public AppData Data { get; private set; }
    public AppUI Menu { get; private set; }

    public App(string path = "Drives")
    {
        // Filling fields
        Data = new AppData(this);
        Menu = new AppUI(this);

        // Adding path
        Data.Path = path;

        // Showing UI
        Menu.ShowFolder();
    }
}
