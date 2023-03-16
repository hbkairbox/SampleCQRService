using SampleCQRService.Commands.CreateCategory;
using SampleCQRService.Commands.DeleteCategory;
using SampleCQRService.Commands.UpdateCategory;
using SampleCQRService.Queries.GetCategories;
using SampleCQRService.Queries.GetCategoriesCount;

namespace SampleCQRService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoryController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<ActionResult> CreateCategoryAsync([FromBody] CreateCategoryDto dto)
    {
        var commandResult = await _mediator.Send(new CreateCategoryCommand(dto));

        return Ok(commandResult);

    }

    [HttpPut]
    public async Task<ActionResult> UpdateCategoryAsync([FromBody] UpdateCategoryDto dto, [FromHeader(Name = "x-requestid")] string requestId)
    {
        if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
        {
            await _mediator.Send(new UpdateCategoryCommand(dto, guid));

            return Ok();
        }

        return BadRequest();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteCategoryAsync([FromHeader(Name = "x-requestid")] string requestId)
    {
        if (!Guid.TryParse(requestId, out Guid guid) || guid == Guid.Empty)
            return BadRequest();

        var commandResult = await _mediator.Send(new DeleteCategoryCommand(guid));

        if (!commandResult)
            return BadRequest();

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> GetCategoriesAsync()
    {
        var queryResult = await _mediator.Send(new GetCategoriesQuery());

        return Ok(queryResult);
    }

    [HttpGet("{categoryName}/count")]
    public async Task<ActionResult> GetCategoriesCountQueryAsync(string categoryName)
    {
        var queryResult = await _mediator.Send(new GetCategoriesCountQuery(categoryName));

        return Ok(queryResult);
    }
}
