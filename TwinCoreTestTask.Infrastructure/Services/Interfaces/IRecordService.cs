using TwinCoreTestTask.Infrastructure.DTO;

namespace TwinCoreTestTask.Infrastructure.Services.Interfaces;

// TODO Lack picture adding
public interface IRecordService
{
    void Add(RecordDto record);

    IEnumerable<RecordDto> GetRecords(int page = 0);

    IEnumerable<RecordDto> Search(string contentPart, int page = 0);

    IEnumerable<RecordDto> Search(DateTime startDate, DateTime endDate, int page = 0);

    void Remove(RecordDto record);
}
