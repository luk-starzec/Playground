using MediatR;
using MediatRExample.Commands;
using MediatRExample.Models;
using MediatRExample.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatRExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator mediator;

        public ItemController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var query = new GetAllItemsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var query = new GetItemQuery(id);
            var result = await mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemModel model)
        {
            var command = new CreateItemCommand(model);
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetItem), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, [FromBody] UpdateItemModel model)
        {
            var command = new UpdateItemCommand
            {
                ItemId = id,
                Item = model
            };
            var result = await mediator.Send(command);

            if (result.IsSuccess)
                return NoContent();

            return string.IsNullOrEmpty(result.Error)
                ? NotFound()
                : StatusCode(500, result.Error);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var command = new DeleteItemCommand(id);
            var result = await mediator.Send(command);

            if (result.IsSuccess)
                return NoContent();

            return string.IsNullOrEmpty(result.Error)
                ? NotFound()
                : StatusCode(500, result.Error);
        }

    }
}
