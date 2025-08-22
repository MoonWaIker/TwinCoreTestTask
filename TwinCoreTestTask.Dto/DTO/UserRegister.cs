using System.ComponentModel.DataAnnotations;

namespace TwinCoreTestTask.Dto.DTO;

public sealed record UserRegister : UserCredentials
{
    [Required]
    public string UserName { get; set; } = string.Empty;
}
