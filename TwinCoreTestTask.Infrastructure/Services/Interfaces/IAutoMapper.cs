using TwinCoreTestTask.DataBase.Entities;
using TwinCoreTestTask.Dto.DTO;

namespace TwinCoreTestTask.Infrastructure.Services.Interfaces;

public interface IAutoMapper
{
    RecordEntity Map(RecordDto source);

    IEnumerable<RecordDto> Map(IEnumerable<RecordEntity> source);
}
