using System.ComponentModel.DataAnnotations;
using TwinCoreTestTask.Core.Abstractions;

namespace TwinCoreTestTask.Dto.DTO;

public sealed record RecordDto : Record
{
    [Required]
    [MaxLength(50)]
    public override required string Title
    {
        get => base.Title;
        init => base.Title = value;
    }

    [Required]
    [MaxLength(500)]
    public override required string Text
    {
        get => base.Text;
        init => base.Text = value;
    }
}
