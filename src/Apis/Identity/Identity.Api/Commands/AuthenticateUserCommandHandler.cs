using System.Threading;
using System.Threading.Tasks;
using Identity.Data.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Identity.Data.Entities;
using Checkout.Common.Infrastructure.Exceptions;
using Identity.Api.Infrastructure;

namespace Identity.Api.Commands
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, User>
    {
        private readonly IIdentityDbContext dbContext;

        public AuthenticateUserCommandHandler(IIdentityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            //TODO: Password need to be hashed
            var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Username == request.Username && u.Password == request.Password);

            if (user == null)
            {
                throw new CustomException(Constants.ErrorCodes.InvalidCredentials, System.Net.HttpStatusCode.Unauthorized);
            }

            return user;
        }
    }
}
