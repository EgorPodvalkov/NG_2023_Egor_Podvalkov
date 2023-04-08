using static System.Net.Mime.MediaTypeNames;

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
            Console.Write("\n".PadLeft(Console.WindowWidth, '-'));
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
                    case ConsoleKey key when key == ConsoleKey.RightArrow || key == ConsoleKey.Enter:
                        // if Folder
                        if (index < Folders.Count)
                        {
                            Path = Folders[index].FullName;
                            index = 0;
                            upperLine = 0;
                        }
                        // if File
                        else
                        {
                            // open file
                            goodResponce = false;
                        }
                        break;
                

                    // ← or Esc, Open Parent Folder
                    case ConsoleKey key when key == ConsoleKey.LeftArrow || key == ConsoleKey.Escape:
                        var oldPath = new DirectoryInfo(Path);
                        var parent = oldPath.Parent;
                        
                        // if Parent Exist
                        if (parent != null)
                        {
                            Path = parent.FullName;
                            index = Folders.FindIndex(folder => folder.FullName == oldPath.FullName);
                            Console.Write("d");
                        }
                        // if Parent Not Exist
                        else 
                            goodResponce = false;
                        break;

                    // X, Cut File or Folder
                    case ConsoleKey.X:
                        //
                        break;

                    // Delete, Delete File or Folder
                    case ConsoleKey.Delete:
                        //
                        break;

                    // C, Copy File or Folder
                    case ConsoleKey.C:
                        //
                        break;

                    // V, Paste File or Folder
                    case ConsoleKey.V:
                        //
                        break;

                    // E, Exit from App
                    case ConsoleKey.E:
                        close = true;
                        break;

                    default:
                        goodResponce = false;
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
                return $"{bytes} {size} ".PadLeft(_maxSizeLength);
            else
                bytes = (int)(bytes / 1024);
        }
        return "Realy big file";
    }


    private void ShowFolderInfo()
    {
        const ConsoleColor highlightColor = ConsoleColor.Cyan;

        // Showing Directory (Directory: {Path})
        Console.Write("Directory: ");
        WriteHighlightedWord(Path, highlightColor);

        // Moving Instruction
        // Press 'UpArrow' or 'DownArrow' to Move through Files and Folders
        Console.Write("\nPress '");
        WriteHighlightedWord("UpArrow", highlightColor);
        Console.Write("' or '");
        WriteHighlightedWord("DownArrow", highlightColor);
        Console.Write("' to Move through Files and Folders");

        // Opening Instruction
        // Press 'Enter' or 'RightArrow' to Open Folder or File, 'Esc' or 'LeftArrow' to Open Parent Folder
        Console.Write("\nPress '");
        WriteHighlightedWord("Enter", highlightColor);
        Console.Write("' or '");
        WriteHighlightedWord("RightArrow", highlightColor);
        Console.Write("' to Open Folder or File, '");
        WriteHighlightedWord("Esc", highlightColor);
        Console.Write("' or '");
        WriteHighlightedWord("LeftArrow", highlightColor);
        Console.Write("' to Open Parent Folder");

        // Cut and Delete Instruction
        // Press 'X' to Cut File or Folder, 'Delete' to Delete File or Folder
        Console.Write("\nPress '");
        WriteHighlightedWord("X", highlightColor);
        Console.Write("' to Cut File or Folder,  '");
        WriteHighlightedWord("Delete", highlightColor);
        Console.Write("' to Delete File or Folder");

        // Copy and Paste Instruction
        // Press 'C' to Copy File or Folder, 'V' to Paste File or Folder
        Console.Write("\nPress '");
        WriteHighlightedWord("C", highlightColor);
        Console.Write("' to Copy File or Folder, '");
        WriteHighlightedWord("V", highlightColor);
        Console.Write("' to Paste File or Folder");

        // Closing App Instruction
        // Press 'E' to Close App
        Console.Write("\nPress '");
        WriteHighlightedWord("E", highlightColor);
        Console.Write("' to Exit");
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

    private void WriteHighlightedWord(string word, ConsoleColor color)
    {
        // Previous Font Color
        var prevForeground = Console.ForegroundColor;

        // Changing Font Color
        Console.ForegroundColor = color;

        // Console Writing
        Console.Write(word);

        // Returning for Previous Font Color
        Console.ForegroundColor = prevForeground;
    }
}
