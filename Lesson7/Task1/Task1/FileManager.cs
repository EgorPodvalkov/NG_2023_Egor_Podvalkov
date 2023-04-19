namespace Task1;

public static class FileManager
{
    public static bool Delete(FileInfo file)
    {
        try
        {
            File.Delete(file.FullName);
        }
        catch 
        { 
            return false;
        }
        return true;
    }
    public static bool Delete(DirectoryInfo folder)
    {
        try
        {
            // Deleting all Child Folders
            foreach (var childFolder in folder.GetDirectories())
                Delete(childFolder);

            // Deleting all Files
            foreach (var files in folder.GetFiles())
                Delete(files);

            // Deleting Empty Folder
            Directory.Delete(folder.FullName);
        }
        catch 
        { 
            return false;
        }
        return true;
    }

    public static bool Paste(string fromPath,  string toPath, string pasteMod)
    {
        try
        {
            // if Final Path not Exist
            if (!Directory.Exists(toPath)) 
                return false;

            // if user work with File
            if (File.Exists(fromPath))
            {
                toPath += $"\\{new FileInfo(fromPath).Name}";

                // if user Cut File
                if (pasteMod == "Cut")
                    File.Move(fromPath, toPath);

                // if user Copy File
                else if (pasteMod == "Copy")
                    File.Copy(fromPath, toPath);

                // if Bad Mod
                else
                    return false;
            }

            // if user work with Folder
            else if (Directory.Exists(fromPath))
            {
                toPath += $"\\{new DirectoryInfo(fromPath).Name}";

                // if user Cut Folder
                if (pasteMod == "Cut")
                    Directory.Move(fromPath, toPath);

                // if user Copy Folder
                else if (pasteMod == "Copy")
                    CopyDirectory(fromPath, toPath);

                // if Bad Mod
                else
                    return false;
            }

            // if no Files and Folders with this Path
            else
                return false;
        }
        catch
        {
            return false;
        }
        return true;
    }

    private static void CopyDirectory(string fromPath, string toPath) 
    {
        // Creating Folder
        Directory.CreateDirectory(toPath);

        // Copying Child Folders
        foreach(var fromSubPath in Directory.GetDirectories(fromPath))
        {
            var newPath = $"{toPath}\\{new FileInfo(fromSubPath).Name}";
            CopyDirectory(fromSubPath, newPath);
        }

        // Copying Files
        foreach (var file in Directory.GetFiles(fromPath))
        {
            var newPath = $"{toPath}\\{new FileInfo(file).Name}";
            File.Copy(file, newPath);
        }
    }

    public static List<string> Read(string path)
    {
        var list = File.ReadLines(path);
        var consoleWidth = Console.WindowWidth - 1;
        var consoleLines = new List<string>();

        foreach (var l in list)
        {
            var line = l;
            
            // if Line Wider than Console
            while (line.Length > consoleWidth) 
            { 
                // Adding and Shoring line
                consoleLines.Add(line.Substring(0, consoleWidth));
                line = line.Substring(consoleWidth);
            }

            // Adding if Line not Wider than Console 
            consoleLines.Add(line);
        }

        return consoleLines;
    }
}
