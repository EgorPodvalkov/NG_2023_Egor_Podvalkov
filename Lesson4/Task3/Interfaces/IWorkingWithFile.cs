namespace Task3.Interfaces;

public interface IWorkingWithFile
{
    public string ReadFromFile(string filename, Guid role);
    public void WriteToFile(string filename, Guid role);
    public void DeleteFile(string filename, Guid role);
    public void DownloadFile(string filename, Guid role);
    public void CopyFile(string filename, Guid role);
    public void GetDataFromFile(string filename, Guid role);
    public void CheckFile(string filename, Guid role);
    public void SaveToFile(string filename, Guid role);
}

