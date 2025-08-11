using Microsoft.EntityFrameworkCore;
using TwinCoreTestTask.Core.Enums;
using TwinCoreTestTask.Infrastructure.DTOs;

namespace TwinCoreTestTask.DataBase.Entities;

// Didn't use keys according to the task. Otherwise they could be added by PrimaryKey or Key attributes
[Keyless]
public record UserEntity : UserCredentials
{
    public Roles Role { get; init; }
}
