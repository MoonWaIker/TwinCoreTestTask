using TwinCoreTestTask.Infrastructure.DTO;

namespace TwinCoreTestTask.Infrastructure.Services.Interfaces;

// TODO Lack picture adding
public interface IRecordService
{
    void Add(RecordDto record);

    IEnumerable<RecordDto> Search(string contentPart);

    IEnumerable<RecordDto> Search(DateTime startDate, DateTime endDate);

    void Remove(RecordDto record);
}
