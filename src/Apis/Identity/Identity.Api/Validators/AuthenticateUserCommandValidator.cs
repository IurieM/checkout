using FluentValidation;
using Identity.Api.Commands;

namespace Identity.Api.Validators
{
    public class AuthenticateUserCommandValidator : AbstractValidator<AuthenticateUserCommand>
    {
        public AuthenticateUserCommandValidator()
        {
            RuleFor(command => command.Username).NotEmpty();
            RuleFor(command => command.Password).NotEmpty();
        }
    }
}
