namespace Task3.Interfaces;

public interface IReadingFromFile
{
    public string ReadFromFile(string filename, Guid role);
    public void CopyFile(string filename, Guid role);
    public void GetDataFromFile(string filename, Guid role);
    public void CheckFile(string filename, Guid role);
}
