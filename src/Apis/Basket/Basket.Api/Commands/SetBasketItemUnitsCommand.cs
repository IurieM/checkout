using Basket.Api.Models;
using MediatR;

namespace Basket.Api.Commands
{
    public class SetBasketItemUnitsCommand : IRequest<BasketItemUnitsModel>
    {
        public int BasketId { get; set; }
        public int ItemId { get; set; }
        public int Units { get; set; }
    }
}
