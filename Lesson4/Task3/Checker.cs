using Task3.Interfaces;

namespace Task3;

public class Checker : IChecker
{
    public Guid CheckRole()
    {
        return Guid.NewGuid();
    }

    public Guid CheckUser()
    {
        return Guid.NewGuid();
    }
}
