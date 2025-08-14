using TwinCoreTestTask.DataBase.Contexts;
using TwinCoreTestTask.Infrastructure.DTO;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Infrastructure.Services;

public class RecordService(TwinCoreDbContext dbContext, IAutoMapper mapper) : IRecordService
{
    public void Add(RecordDto record)
    {
        dbContext.Records.Add(mapper.Map(record));

        dbContext.SaveChanges();
    }

    public void Remove(RecordDto record)
    {
        dbContext.Records.Remove(dbContext.Records
            .Find(mapper.Map(record)) ?? throw new InvalidOperationException());

        dbContext.SaveChanges();
    }

    public IEnumerable<RecordDto> Search(string contentPart)
    {
        var records = dbContext.Records
            .Where(r => r.Text.Contains(contentPart, StringComparison.OrdinalIgnoreCase)
                       || r.Title.Contains(contentPart, StringComparison.OrdinalIgnoreCase));

        return mapper.Map(records);
    }

    public IEnumerable<RecordDto> Search(DateTime startDate, DateTime endDate)
    {
        var records = dbContext.Records
            .Where(r => r.PublicationDate >= startDate && r.PublicationDate <= endDate);

        // Map entities to DTOs using AutoMapper
        return mapper.Map(records);
    }
}
