namespace Task1;

public class App
{
    // Public Fields
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
                _tableLines = new List<string>();

                // Filling 'Folders' and _tableLines Field with Folders from Directory Path
                foreach (var f in Directory.GetDirectories(value))
                {
                    var folder = new DirectoryInfo(f);
                    
                    // Adding Folder to List
                    Folders.Add(folder);
                    
                    // Adding Table Line to List
                    var line = FormatName(folder.Name);
                    line += folder.LastWriteTime.ToString(_dateFormat);
                    line += "".PadLeft(_maxSizeLength);
                    _tableLines.Add(line);
                }

                // Filling 'Files' and _tableLines Field with Files from Directory Path
                foreach (var f in Directory.GetFiles(value))
                {
                    var file = new FileInfo(f);

                    // Adding File to List
                    Files.Add(file);

                    // Adding Table Line to List
                    var line = FormatName(file.Name);
                    line += file.LastWriteTime.ToString(_dateFormat);
                    line += FormatByteSize(file.Length);
                    _tableLines.Add(line);
                }

            }
            // if Not Exist
            else
            {
                _path = "Error Directory";
                Folders = new List<DirectoryInfo>();
                Files = new List<FileInfo>();
            }
        }
    }
    public List<DirectoryInfo> Folders { get; private set; }
    public List<FileInfo> Files { get; private set; }

    // Private Fields
    private string _path;
    private List<string> _tableLines = new List<string>();
    private const int _maxLines = 20;
    private const int _linesPad = 3;
    private const int _maxNameLength = 40;
    private const string _dateFormat = "dd.MM.yy    HH:mm";
    private const int _maxSizeLength = 10;

    public App(string path)
    {
        Path = path;
    }

    public void ShowFolder() 
    {
        int index = 0;
        int upperLine = 0;
        bool close = false;
        while (true)
        {
            // Console Clearing
            Console.Clear();

            // Files Table 
            ShowFilesTable(index, upperLine);

            // Instructions for Menu
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("".PadLeft(Console.WindowWidth, '-'));
            Console.ForegroundColor = ConsoleColor.Gray;
            ShowFolderInfo();

            while (true)
            {
                // Getting Response
                var response = Console.ReadKey().Key;
                bool goodResponce = true;

                switch (response)
                {
                    // ↓, Moving Down
                    case ConsoleKey.DownArrow:
                        // if on Button
                        if (index == Folders.Count + Files.Count - 1)
                            goodResponce = false;
                        
                        // Scroll Down and Move
                        else if (index >= upperLine + _maxLines - _linesPad 
                            && upperLine + _maxLines != Folders.Count + Files.Count)
                        {
                            index++;
                            upperLine = index - _maxLines + _linesPad;
                        }

                        // Only Move
                        else
                            index++;

                        break;

                    // ↑, Moving Up
                    case ConsoleKey.UpArrow:
                        // if on Top
                        if (index == 0)
                            goodResponce = false;

                        // Scroll Pp and Move
                        else if (index < upperLine + _linesPad
                            && upperLine != 0)
                        {
                            upperLine = index - _linesPad;
                            index--;
                        }

                        // Only Move
                        else
                            index--;

                        break;

                    // → or Enter, Open Folder or File
                    case ConsoleKey.RightArrow:
                        break;
                }

                // Exit from Getting Response
                if (goodResponce)
                    break;
            }

            // Exit from App Menu
            if (close)
                break;
        }
    }

    private string FormatName(string name)
    {
        // if Name should be Colapse
        if (name.Length > _maxNameLength)
            name = $" {name.Substring(0, _maxNameLength - 3)}...";
        // if Name should be Expanded
        else
            name = $" {name}".PadRight(_maxNameLength);
        
        return name;
    }

    private string FormatByteSize(long bytes)
    {
        var sizes = new List<string>() 
        { "B", "KB", "MB", "GB", "TB", "PB" };

        foreach (var size in sizes)
        {
            if (bytes < 1024)
                return $"{bytes} {size}".PadLeft(_maxSizeLength);
            else
                bytes = (int)(bytes / 1024);
        }
        return "Realy big file";
    }

    private void WriteHighlightedLine(string text)
    {
        // Previous Font and Bg Color
        var prevBackground = Console.BackgroundColor;
        var prevForeground = Console.ForegroundColor;
        
        // Changing Font and Bg Color
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;
        
        // Console Writing
        Console.WriteLine(text);

        // Returning for Previous Font and Bg Color
        Console.ForegroundColor = prevForeground;
        Console.BackgroundColor = prevBackground;
    }

    private void ShowFolderInfo()
    {
        // Showing Directory 
        Console.WriteLine($"Directory: {Path}");

        // Moving Instruction
        Console.WriteLine("Press 'UpArrow' or 'DownArrow' to Move through Files and Folders");
        
        // Opening Instruction
        Console.WriteLine(
            "Press 'Enter' or 'RightArrow' to Open Folder or File, " +
            "'Esc' or 'LeftArrow' to Open Parent Folder");
    }

    private void ShowFilesTable(int index, int upperLine)
    {
        // Table Head
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"{index + 1} of {_tableLines.Count}");
        //Console.WriteLine(" Name ");

        // Table Body
        Console.ForegroundColor = ConsoleColor.White;
        for (int i = upperLine; i < _tableLines.Count && i < upperLine + _maxLines; i++)
        {
            var line = _tableLines[i];
            // Visualizing Differents between Folders and Files
            if (i >= Folders.Count)
                Console.ForegroundColor = ConsoleColor.Gray;

            // Highlight Point for User
            if (i == index)
                WriteHighlightedLine(line);
            else
                Console.WriteLine(line);
        }

        // Adding Insufficient Lines
        for (int i = 0; i < _maxLines - _tableLines.Count; i++)
            Console.WriteLine();
    }
}
