namespace Task3.Interfaces;

public interface IUserChecker
{
    public Guid CheckRole(Guid roleId);
    public Guid CheckUser(Guid user);
}
