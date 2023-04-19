namespace Task1;

public static class FileManager
{
    public static bool Delete(FileInfo file) => DeleteAsync(file).Result;
    public static bool Delete(DirectoryInfo folder) => DeleteAsync(folder).Result;

    private async static Task<bool> DeleteAsync(FileInfo file)
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

    private async static Task<bool> DeleteAsync(DirectoryInfo folder)
    {
        try
        {
            // Deleting all Child Folders
            foreach (var childFolder in folder.GetDirectories())
                await DeleteAsync(childFolder);

            // Deleting all Files
            foreach (var files in folder.GetFiles())
                await DeleteAsync(files);

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
                    CopyDirectoryAcync(fromPath, toPath).Wait();

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

    private async static Task CopyDirectoryAcync(string fromPath, string toPath) 
    {
        // Creating Folder
        Directory.CreateDirectory(toPath);

        // Copying Child Folders
        foreach(var fromSubPath in Directory.GetDirectories(fromPath))
        {
            var newPath = $"{toPath}\\{new FileInfo(fromSubPath).Name}";
            await CopyDirectoryAcync(fromSubPath, newPath);
        }

        // Copying Files
        foreach (var file in Directory.GetFiles(fromPath))
        {
            await CopyFileAcync(file, toPath);
        }
    }

    private async static Task CopyFileAcync(string file, string toPath)
    {
        var newPath = $"{toPath}\\{new FileInfo(file).Name}";
        File.Copy(file, newPath);
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
