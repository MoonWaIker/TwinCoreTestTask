using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TwinCoreTestTask.DataBase.Entities;

[PrimaryKey(nameof(Token))]
[Index(nameof(Email), IsUnique = true)]
public sealed record RegisterInvitation
{
    public required Guid Token { get; init; }

    [EmailAddress]
    public required string Email { get; init; }

    public DateTime ExpiresAt { get; init; }
}
