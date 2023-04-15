namespace Task3.Interfaces;

public interface IFileWorker
{
    public string ReadFromFile(string filename);
    public void WriteToFile(string filename);
    public void GetDataFromFile(string filename);
}
