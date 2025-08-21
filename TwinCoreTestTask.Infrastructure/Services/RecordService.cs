using TwinCoreTestTask.DataBase.Contexts;
using TwinCoreTestTask.Dtos.DTO;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Infrastructure.Services;

public sealed class RecordService(TwinCoreDbContext dbContext, IAutoMapper mapper, TimeProvider timeProvider)
    : IRecordService
{
    private const int PageSize = 5; // Assuming a default page size for pagination
    private const int MaxRecordAgeAllowedToEditInDays = 2;

    public void Add(RecordDto record)
    {
        dbContext.Records.Add(mapper.Map(record));

        dbContext.SaveChanges();
    }

    public IEnumerable<RecordDto> GetRecords(int page = 0)
    {
        return mapper.Map(dbContext.Records
            .Skip(page * PageSize)
            .Take(PageSize));
    }

    public void Remove(RecordDto record)
    {
        if (timeProvider.GetUtcNow().Day - record.PublicationDate.Day >= MaxRecordAgeAllowedToEditInDays)
        {
            // TODO Replace it with custom exception to handle it in Middleware correctly
            throw new InvalidOperationException();
        }

        dbContext.Records.Remove(dbContext.Records
            .Find(mapper.Map(record)) ?? throw new InvalidOperationException());

        dbContext.SaveChanges();
    }

    public IEnumerable<RecordDto> Search(string contentPart, int page = 0)
    {
        return mapper.Map(dbContext.Records
            .Where(r => r.Text.Contains(contentPart)
                        || r.Title.Contains(contentPart))
            .Skip(page * PageSize)
            .Take(PageSize));
    }

    public IEnumerable<RecordDto> Search(DateTime startDate, DateTime endDate, int page = 0)
    {
        return mapper.Map(dbContext.Records
            .Where(r => r.PublicationDate >= startDate && r.PublicationDate <= endDate)
            .Skip(page * PageSize)
            .Take(PageSize));
    }
}
