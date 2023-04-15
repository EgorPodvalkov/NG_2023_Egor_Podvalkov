namespace Task3.Interfaces;

public interface IFileSystem
{
    public void DeleteFile(string filename);
    public void DownloadFile(string filename);
    public void CopyFile(string filename);
    public void CheckFile(string filename);
    public void SaveToFile(string filename);
}
