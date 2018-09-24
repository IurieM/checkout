using Identity.Api.Commands;
using Identity.Api.Models;
using Identity.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthenticationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody]AuthenticateUserCommand authenticateUser)
        {
            var user = await mediator.Send(authenticateUser);
            var jwtToken = await mediator.Send(new GenerateTokenCommand(user.Id, user.Username));
            var userModel = new UserModel()
            {
                Id = user.Id,
                Username = user.Username,
                Token = jwtToken
            };
            return Ok(userModel);
        }
    }
}
