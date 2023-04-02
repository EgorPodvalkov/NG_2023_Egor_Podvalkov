using Task3.Interfaces;

namespace Task3;

public class UsersManager : IUserChecker
{
    public Guid CheckRole(Guid roleId)
    {
        return Guid.NewGuid();
    }

    public Guid CheckUser(Guid user)
    {
        return Guid.NewGuid();
    }
}
