using System.ComponentModel.DataAnnotations;

namespace TwinCoreTestTask.Dto.DTO;

public sealed record UserRegister : UserCredentials
{
    [Required]
    public required string UserName { get; init; }
}
