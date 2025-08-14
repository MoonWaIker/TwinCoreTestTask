using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwinCoreTestTask.Infrastructure.DTO;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Controllers;

[ApiController]
[Route(_route)]
[Authorize]
public class RecordsController(IRecordService service) : ControllerBase
{
    private const string _route = "api/[controller]";
    private const string _searchByContentPart = "search/{contentPart}";
    private const string _searchByDateRange = "search/date";

    [HttpPost]
    public IActionResult CreateRecord([FromBody] RecordDto recordDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        service.Add(recordDto);

        return Ok();
    }

    [HttpGet(_searchByContentPart)]
    public ActionResult<IEnumerable<RecordDto>> SearchRecords(string contentPart)
    {
        return Ok(service.Search(contentPart));
    }

    [HttpGet(_searchByDateRange)]
    public ActionResult<IEnumerable<RecordDto>> SearchRecords(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate)
    {
        return Ok(service.Search(startDate, endDate));
    }

    [HttpDelete]
    public IActionResult DeleteRecord([FromBody] RecordDto recordDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        service.Remove(recordDto);

        return Ok();
    }
}
