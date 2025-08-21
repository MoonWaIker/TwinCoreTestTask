using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TwinCoreTestTask.DataBase.Entities;

[Keyless]
public sealed record RegisterInvitation
{
    [EmailAddress]
    public required string Email { get; init; }

    public required Guid Token { get; init; }

    public DateTime ExpiresAt { get; init; }
}
