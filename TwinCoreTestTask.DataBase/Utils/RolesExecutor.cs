using System.Globalization;
using Microsoft.AspNetCore.Identity;
using TwinCoreTestTask.Core.Enums;

namespace TwinCoreTestTask.DataBase.Utils;

public static class RolesExecutor
{
    public static IEnumerable<IdentityRole> Roles
    {
        get
        {
            var roleNames = Enum.GetNames<Roles>();
            var roleNumbers = Enum.GetValues<Roles>();

            return roleNames
                .Zip(roleNumbers, (name, value) => new IdentityRole
                {
                    Id = ((int)value).ToString(CultureInfo.InvariantCulture),
                    Name = name,
                    NormalizedName = name.ToUpperInvariant(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
        }
    }
}
