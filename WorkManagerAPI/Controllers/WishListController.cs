using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.Application.Commands.WishLists.Create;
using WM.Application.Commands.WishLists.Delete;

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
    }
}
