﻿using Task3.Interfaces;

namespace Task3;

public class FilesManager : IWorkingWithFile
{
    public string ReadFromFile(string filename, Guid role)
    {
        var checkedRole = new UsersManager().CheckRole(role);
        return "Readed Data";
    }
    public void WriteToFile(string filename, Guid role)
    {
        var checkedRole = new UsersManager().CheckRole(role);
        Console.WriteLine("Data Written");
    }
    public void DeleteFile(string filename, Guid role)
    {
        var checkedRole = new UsersManager().CheckRole(role);
        Console.WriteLine("File Deleted");
    }
    public void DownloadFile(string filename, Guid role)
    {
        var checkedRole = new UsersManager().CheckRole(role);
        Console.WriteLine("File Downloaded");
    }
    public void CopyFile(string filename, Guid role)
    {
        var checkedRole = new UsersManager().CheckRole(role);
        Console.WriteLine("File Copied");
    }
    public void GetDataFromFile(string filename, Guid role)
    {
        var checkedRole = new UsersManager().CheckRole(role);
        Console.WriteLine("Data Get");
    }
    public void CheckFile(string filename, Guid role)
    {
        var checkedRole = new UsersManager().CheckRole(role);
        Console.WriteLine("File Checked");
    }
    public void SaveToFile(string filename, Guid role)
    {
        var checkedRole = new UsersManager().CheckRole(role);
        Console.WriteLine("File Saved");
    }
}
