using System.ComponentModel.DataAnnotations;

namespace TwinCoreTestTask.Infrastructure.DTO;

public record UserCredentials
{
    [Required]
    public required string Email { get; init; }

    [Required]
    public required string Password { get; init; }
}
