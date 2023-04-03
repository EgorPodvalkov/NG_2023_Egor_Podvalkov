namespace Task3.Interfaces;

public interface IEditingFile
{
    public void WriteToFile(string filename, Guid role);
    public void DeleteFile(string filename, Guid role);
    public void DownloadFile(string filename, Guid role);
    public void SaveToFile(string filename, Guid role);
}
