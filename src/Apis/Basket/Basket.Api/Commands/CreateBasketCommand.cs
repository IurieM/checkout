using Basket.Api.Models;
using MediatR;

namespace Basket.Api.Commands
{
    public class CreateBasketCommand : IRequest<BasketModel>
    {
        public int UserId { get; set; }
    }
}
