using MediatR;

namespace Identity.Api.Queries
{
    public class GenerateTokenCommand:IRequest<string>
    {
        public int UserId { get; set; }
        public string Username { get; set; }

        public GenerateTokenCommand(int userId, string username)
        {
            UserId = userId;
            Username = username;
        }
    }
}
