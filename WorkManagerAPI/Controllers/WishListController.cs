using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.Application.Commands.WishLists.Create;
using WM.Application.Commands.WishLists.Delete;
using WM.Application.Commands.WishLists.Update;
using WM.Application.Queries.WishLists.Get;
using WM.Application.Queries.WishLists.List;

namespace WorkManagerAPI.Controllers
{
    [Route("api/wishList")]
    [Produces("application/json")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IMediator mediator;

        public WishListController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateWishListCommand command)
        {
            return Created(string.Empty, await this.mediator.Send(command));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteWishListCommand command)
        {
            return Ok(await this.mediator.Send(command));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateWishListCommand command)
        {
            return Ok(await this.mediator.Send(command));
        }

        [HttpGet("list")]
        public async Task<IActionResult> List([FromQuery] ListWishListQuery query)
        {
            return Ok(await this.mediator.Send(query));
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] GetWishListQuery query)
        {
            return Ok(await this.mediator.Send(query));
        }
    }
}
