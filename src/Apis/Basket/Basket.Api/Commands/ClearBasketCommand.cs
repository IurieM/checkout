using Basket.Api.Models;
using MediatR;

namespace Basket.Api.Commands
{
    public class ClearBasketCommand : IRequest<BasketModel>
    {
        public int BasketId { get; set; }
    }
}
