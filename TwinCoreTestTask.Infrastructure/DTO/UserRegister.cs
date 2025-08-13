using System.ComponentModel.DataAnnotations;

namespace TwinCoreTestTask.Infrastructure.DTO;

public record UserRegister : UserCredentials
{
    [Required]
    public required string UserName { get; init; }
}
