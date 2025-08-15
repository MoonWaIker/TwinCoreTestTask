using System.Collections;
using Microsoft.AspNetCore.Identity;

namespace TwinCoreTestTask.DataBase.Tests.CustomComparers;

public class IdentityUserComparer : IComparer, IComparer<IdentityRole>
{
    public static readonly IdentityUserComparer Instance = new();

    public int Compare(object? x, object? y)
    {
        return Compare(x as IdentityRole, y as IdentityRole);
    }

    public int Compare(IdentityRole? x, IdentityRole? y)
    {
        if (x == null && y == null)
        {
            return 0;
        }

        if (x == null)
        {
            return -1;
        }

        if (y == null)
        {
            return 1;
        }

        var idComparison = string.Compare(x.Id, y.Id, StringComparison.Ordinal);
        if (idComparison != 0)
        {
            return idComparison;
        }

        var nameComparison = string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        if (nameComparison != 0)
        {
            return nameComparison;
        }

        return string.Compare(x.NormalizedName, y.NormalizedName, StringComparison.Ordinal);
    }
}
