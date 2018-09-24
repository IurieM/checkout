using Identity.Data.Entities;
using MediatR;

namespace Identity.Api.Commands
{
    public class AuthenticateUserCommand: IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
