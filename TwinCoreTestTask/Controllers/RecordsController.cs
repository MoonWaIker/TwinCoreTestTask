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
    private const string _getRoute = "{page:int}";
    private const string _searchByDateRange = "search/date/{page:int}";
    private const string _searchByContentPart = "search/{contentPart}/{page:int}";

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

    [HttpGet(_getRoute)]
    public ActionResult<IEnumerable<RecordDto>> GetRecords(int page)
    {
        return Ok(service.GetRecords(page));
    }

    [HttpGet(_searchByContentPart)]
    public ActionResult<IEnumerable<RecordDto>> SearchRecords(string contentPart, int page)
    {
        return Ok(service.Search(contentPart, page));
    }

    [HttpGet(_searchByDateRange)]
    public ActionResult<IEnumerable<RecordDto>> SearchRecords(
        [FromRoute] int page,
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate)
    {
        return Ok(service.Search(startDate, endDate, page));
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
