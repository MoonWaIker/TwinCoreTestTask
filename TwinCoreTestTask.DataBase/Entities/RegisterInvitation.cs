using Microsoft.EntityFrameworkCore;

namespace TwinCoreTestTask.DataBase.Entities;

[Keyless]
public record RegisterInvitation
{
    public required string Email { get; init; }

    public required Guid Token { get; init; }

    public DateTime ExpiresAt { get; init; }
}
