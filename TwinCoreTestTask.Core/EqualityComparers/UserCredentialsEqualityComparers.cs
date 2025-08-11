using TwinCoreTestTask.Infrastructure.DTOs;

namespace TwinCoreTestTask.Core.EqualityComparers;

public class UserCredentialsEqualityComparers : IEqualityComparer<UserCredentials>
{
    public bool Equals(UserCredentials? x, UserCredentials? y)
    {
        if (x == null && y == null)
        {
            return true;
        }

        if (x == null || y == null)
        {
            return false;
        }

        return x.Email == y.Email
                && x.Password == y.Password;
    }

    public int GetHashCode(UserCredentials obj)
    {
        return obj is null
            ? default
            : HashCode.Combine(obj.Email, obj.Password);
    }
}
