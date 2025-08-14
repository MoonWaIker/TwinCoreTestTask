namespace TwinCoreTestTask.Core.Abstractions;

public abstract record Record
{
    public virtual required string Title { get; init; }

    public virtual required string Text { get; init; }

    public virtual DateTime PublicationDate { get; init; }
}
