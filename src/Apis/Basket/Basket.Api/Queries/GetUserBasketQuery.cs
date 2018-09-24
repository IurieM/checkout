using Basket.Api.Models;
using MediatR;

namespace Basket.Api.Commands
{
    public class GetUserBasketQuery : IRequest<BasketModel>
    {
        public int UserId { get; set; }
    }
}
