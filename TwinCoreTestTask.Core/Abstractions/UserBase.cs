namespace TwinCoreTestTask.Core.Abstractions;

public record UserBase
{
    public virtual required string Email { get; init; }
}
