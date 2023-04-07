using Task3.Interfaces;

namespace Task3;

public class UsersManager : IUserChecker
{
    public Guid CheckRole(Guid roleId)
    {
        return roleId;
    }

    public Guid CheckUser(Guid user)
    {
        return user;
    }
}
