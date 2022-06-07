using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WM.Application.Commands.Users.Login;
using WM.Application.Commands.Users.Register;

namespace WorkManagerAPI.Controllers
{

    

    [Route("api/user")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }



        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RegisterUserCommand command)
        {
            return Created(string.Empty, await this.mediator.Send(command));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            return Created(string.Empty, await this.mediator.Send(command));
        }

    }
}
