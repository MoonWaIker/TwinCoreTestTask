using System.ComponentModel.DataAnnotations;

namespace TwinCoreTestTask.Dto.DTO;

public record UserCredentials
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
