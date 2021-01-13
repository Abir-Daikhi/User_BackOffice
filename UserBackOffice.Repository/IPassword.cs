using UserBackOffice.Models;

namespace UserBackOffice.Repository
{
    public interface IPassword
    {
        long? SavePassword(Password password);
        string GetPasswordbyUserId(long userId);
    }
}
