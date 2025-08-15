using System.Collections;
using Microsoft.AspNetCore.Identity;
using TwinCoreTestTask.DataBase.Tests.CustomComparers;
using TwinCoreTestTask.DataBase.Utils;

namespace TwinCoreTestTask.DataBase.Tests.Tests;

[TestClass]
public class RolesExecutorTest
{
    private static readonly ICollection<IdentityRole> ExpectedRoles =
    [
        new IdentityRole
        {
            Id = "0",
            Name = "User",
            NormalizedName = "USER"
        },
        new IdentityRole
        {
            Id = "1",
            Name = "Admin",
            NormalizedName = "ADMIN"
        }
    ];

    [TestMethod]
    public void AreRolesCorrect()
    {
        var actual = RolesExecutor.Roles.ToArray();

        CollectionAssert.AreEqual((ICollection)ExpectedRoles, actual, IdentityUserComparer.Instance);
    }
}
