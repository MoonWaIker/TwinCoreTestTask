using System.ComponentModel.DataAnnotations;
using TwinCoreTestTask.Core.Abstractions;

namespace TwinCoreTestTask.Infrastructure.DTOs;

public record UserCredentials : UserBase
{
    [Required]
    public override required string Email { get; init; }

    [Required]
    public required string Password { get; init; }
}
