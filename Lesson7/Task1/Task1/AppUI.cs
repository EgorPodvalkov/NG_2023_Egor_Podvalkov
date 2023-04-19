namespace Task1;

public class AppUI
{
    private App _app;
    private List<string> _tableLines = new List<string>();
    private const int _maxLines = 19;
    private const int _linesPad = 3;
    private const int _maxNameLength = 40;
    private const string _dateFormat = "dd.MM.yy    HH:mm";
    private const int _maxSizeLength = 10;

    public AppUI(App app) 
    { 
        _app = app;
    }

    public void GenerateTableLines()
    {
        _tableLines = new List<string>();
        
        // Adding Table Lines with Folders to List
        foreach (var folder in _app.Data.Folders)
        {
            var line = FormatName(folder.Name);
            line += folder.LastWriteTime.ToString(_dateFormat);
            line += "".PadLeft(_maxSizeLength);
            _tableLines.Add(line);
        }

        // Adding Table Lines with Files to List
        foreach (var file in _app.Data.Files)
        {
            var line = FormatName(file.Name);
            line += file.LastWriteTime.ToString(_dateFormat);
            line += FormatByteSize(file.Length);
            _tableLines.Add(line);
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

    public void ShowFolder()
    {
        int index = 0;
        int upperLine = 0;
        bool close = false;
        while (true)
        {
            // Bad Index
            if (index < 0 || index >= _tableLines.Count)
                index = 0;
            // Console Clearing
            Console.Clear();

            // Files Table 
            ShowTable(index, upperLine);

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
                        if (index == _tableLines.Count - 1)
                        {
                            index = 0;
                            upperLine = 0;
                        }
                            
                        // Scroll Down and Move
                        else if (index >= upperLine + _maxLines - _linesPad
                            && upperLine + _maxLines != _tableLines.Count)
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
                        {
                            index = _tableLines.Count - 1;
                            if (_tableLines.Count < _maxLines)
                                upperLine = 0;
                            else
                                upperLine = _tableLines.Count - _maxLines;
                        }

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
                        if (index < _app.Data.Folders.Count)
                        {
                            try
                            {
                                _app.Data.Path = _app.Data.Folders[index].FullName;
                                index = 0;
                                upperLine = 0;
                            }
                            catch 
                            { 
                                var path = _app.Data.Path;
                                Console.Clear();
                                Console.WriteLine($"No Access to {path}");
                                _app.Data.Path = new DirectoryInfo(path).Parent.FullName;
                                Console.ReadKey();
                            }
                        }
                        // if File
                        else
                        {
                            var filePath = _app.Data.Files[index - _app.Data.Folders.Count].FullName;
                            ShowFile(filePath);
                        }
                        break;


                    // ← or Esc, Open Parent Folder
                    case ConsoleKey key when key == ConsoleKey.LeftArrow || key == ConsoleKey.Escape:
                        var oldPath = new DirectoryInfo(_app.Data.Path);
                        var parent = oldPath.Parent;
                        Console.Write("d");

                        // if in Drives
                        if (_app.Data.Path == "Drives")
                            goodResponce = false;
                        // Error Handler
                        else if (_app.Data.Path == "Error Directory, Press Esc")
                        {
                            _app.Data.Path = "Drives";
                        }
                        // if Parent Exist
                        else if (parent != null)
                        {
                            _app.Data.Path = parent.FullName;
                            index = _app.Data.Folders.FindIndex(folder => folder.FullName == oldPath.FullName);

                            // if we can`t find Folder
                            if (index == -1)
                                index = 0;

                            // Scroll Settings
                            if (index < _maxLines / 2 || _maxLines > _tableLines.Count)
                                upperLine = 0;
                            else if (index > _tableLines.Count - _maxLines / 2)
                                upperLine = _tableLines.Count - _maxLines;
                            else 
                                upperLine = index - _maxLines / 2;
                        }
                        // if Parent is Drives List
                        else
                        {
                            _app.Data.Path = "Drives";
                            index = _app.Data.Folders.FindIndex(folder => folder.FullName == oldPath.FullName);

                            // Scroll Settings
                            if (index < _maxLines / 2 || _maxLines > _tableLines.Count)
                                upperLine = 0;
                            else if (index > _tableLines.Count - _maxLines / 2)
                                upperLine = _tableLines.Count - _maxLines;
                            else
                                upperLine = index - _maxLines / 2;
                        }
                        break;

                    // X, Cut File or Folder
                    case ConsoleKey.X:
                        _app.Data.PasteMod = "Cut";
                        _app.Data.SetBufferPath(index);
                        break;

                    // Delete, Delete File or Folder
                    case ConsoleKey.Delete:
                        // if Folder
                        if (index < _app.Data.Folders.Count)
                        {
                            ShowDeleteQuestion(_app.Data.Folders[index]);
                        }
                        // if File
                        else
                        {
                            ShowDeleteQuestion(_app.Data.Files[index - _app.Data.Folders.Count]);
                        }
                        // if Deleted Last File
                        if (index == _tableLines.Count)
                            index--;
                        // Upload Data
                        _app.Data.Path = _app.Data.Path;
                        break;

                    // C, Copy File or Folder
                    case ConsoleKey.C:
                        _app.Data.PasteMod = "Copy";
                        _app.Data.SetBufferPath(index);
                        break;

                    // V, Paste File or Folder
                    case ConsoleKey.V:
                        if (_app.Data.PasteMod == "")
                            goodResponce = false;
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"{_app.Data.PasteMod}ing...");

                            if (FileManager.Paste(_app.Data.BufferPath, _app.Data.Path, _app.Data.PasteMod))
                            {
                                Console.WriteLine("\nSuccess!");
                                _app.Data.Path = _app.Data.Path;
                            }
                            else
                            {
                                Console.WriteLine("\nSomething Wrong :(");
                            }
                            _app.Data.SetBufferPath();
                            _app.Data.PasteMod = "";
                            Console.ReadKey();
                        }
                        break;

                    // F, Go to Path
                    case ConsoleKey.F:
                        ShowSearch();
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
                else
                    Console.Write("\b \b");
            }

            // Exit from App Menu
            if (close)
                break;
        }
    }

    private void ShowFolderInfo()
    {
        const ConsoleColor highlightColor = ConsoleColor.Cyan;

        // Directory Info
        // Directory: {Path}
        Console.Write("Directory: ");
        WriteHighlightedWord(_app.Data.Path, highlightColor);

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

        // Search File or Folder
        // Press 'F' to Open Search Menu
        Console.Write("\nPress '");
        WriteHighlightedWord("F", highlightColor);
        Console.Write("' to Go to File or Folder by Path");


        // Closing App Instruction
        // Press 'E' to Close App
        Console.Write("\nPress '");
        WriteHighlightedWord("E", highlightColor);
        Console.Write("' to Exit");

        // Buffer Info
        // Buffer: {BufferPath}
        var data = _app.Data;
        if (data.BufferPath != "")
        {
            Console.Write($"\nBuffer ({data.PasteMod}): ");
            WriteHighlightedWord(data.BufferPath, highlightColor);
        }
    }

    private void ShowTable(int index, int upperLine)
    {
        // Empty Folder
        if (_tableLines.Count == 0)
        {
            Console.WriteLine("Empty Folder");

            // Adding Insufficient Lines
            for (int i = 0; i < _maxLines; i++)
                Console.WriteLine();
            return;
        }

        // Table Head
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"{index + 1} of {_tableLines.Count}");

        // Table Body
        Console.ForegroundColor = ConsoleColor.White;
        for (int i = upperLine; i < _tableLines.Count && i < upperLine + _maxLines; i++)
        {
            var line = _tableLines[i];
            // Visualizing Differents between Folders and Files
            if (i >= _app.Data.Folders.Count)
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

    private void ShowFile(string path)
    {
        const ConsoleColor highlightColor = ConsoleColor.Cyan;
        var lines = FileManager.Read(path);
        var consoleHeight = Console.WindowHeight - 3;
        var upperLine = 0;
        var close = false;

        while (true)
        {
            Console.Clear();

            // ---------------
            // File: {Path}
            Console.Write($"File: ");
            WriteHighlightedWord(path, highlightColor);
            Console.WriteLine();
            WriteHighlightedWord("\n".PadLeft(Console.WindowWidth, '-'), highlightColor);

            // File Content
            for (int i  = upperLine; i < lines.Count && i < upperLine + consoleHeight; i++)
                Console.WriteLine(lines[i]);

            // Response Handler
            while (true)
            {
                var response = Console.ReadKey().Key;
                var goodResponse = true;

                switch (response)
                { 
                    // ↓, Moving Down
                    case ConsoleKey.DownArrow:
                        // if on Button
                        if (upperLine >= lines.Count - consoleHeight )
                            goodResponse = false;
                        // if All Good
                        else
                            upperLine++;
                        break;

                    // ↑, Moving Up
                    case ConsoleKey.UpArrow:
                        // if on Top
                        if (upperLine == 0)
                            goodResponse = false;
                        // if All Good
                        else
                            upperLine--;
                        break;

                    // Esc or ←, Close File Reader
                    case ConsoleKey key when key == ConsoleKey.LeftArrow || key == ConsoleKey.Escape:
                        close = true;
                        Console.Write('d');
                        break;

                    // Bad Response
                    default:
                        goodResponse = false;
                        break;
                }

                if (goodResponse)
                    break;
                else
                    Console.Write("\b \b");
            }

            if (close)
                break;
        }
        // Console.SetCursorPosition(0, Console.CursorTop - lines.Count);
    }

    private void ShowDeleteQuestion(FileInfo file)
    {
        const ConsoleColor highlightColor = ConsoleColor.Cyan;

        Console.Clear();
        Console.WriteLine("Are you sure to Delete this File: ");
        WriteHighlightedWord(file.FullName, highlightColor);
        Console.Write("\nY / N?\n");

        while (true)
        {
            // Getting Response
            var response = Console.ReadKey().Key;
            bool goodResponce = true;

            switch(response)
            {
                case ConsoleKey.Y:
                    Console.WriteLine("\nDeleting...");
                    
                    if (FileManager.Delete(file))
                        Console.WriteLine("\nSuccess!");
                    else
                        Console.WriteLine("Something wrong :(");
                    Console.ReadKey();
                    break;
                case ConsoleKey.N:
                    break;
                default: 
                    goodResponce = false;
                    break;
            }
            Console.Write("\b \b");
            if (goodResponce) 
                break;
        }
    }

    private void ShowDeleteQuestion(DirectoryInfo folder)
    {
        const ConsoleColor highlightColor = ConsoleColor.Cyan;

        Console.Clear();
        Console.WriteLine("Are you sure to Delete this Folder: ");
        WriteHighlightedWord(folder.FullName, highlightColor);
        Console.Write("\nY / N?\n");

        while (true)
        {
            // Getting Response
            var response = Console.ReadKey().Key;
            bool goodResponce = true;

            switch (response)
            {
                case ConsoleKey.Y:
                    Console.WriteLine("\nDeleting...");

                    if (FileManager.Delete(folder))
                        Console.WriteLine("\nSuccess!");
                    else 
                        Console.WriteLine("Something wrong :(");
                    Console.ReadKey();
                    break;
                case ConsoleKey.N:
                    break;
                default:
                    goodResponce = false;
                    break;
            }
            Console.Write("\b \b");
            if (goodResponce)
                break;
        }
    }

    private void ShowSearch()
    {
        Console.Clear();

        // Enter Path: {UserInput}
        Console.Write("Enter Path: ");
        var response = Console.ReadLine();

        // if Folder
        if (Directory.Exists(response))
            _app.Data.Path = response;

        // if Drives Folder
        else if (response.ToLower() == "drives")
            _app.Data.Path = "Drives";
        
        // if File
        else if (File.Exists(response))
        {
            _app.Data.Path = new FileInfo(response).DirectoryName;
            ShowFile(response);
        }

        // if Bad Path
        else
        {
            Console.WriteLine("Bad Path :(");
            Console.ReadKey();
        }
    }
}
