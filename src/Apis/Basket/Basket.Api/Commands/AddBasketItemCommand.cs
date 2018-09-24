using Basket.Api.Models;
using MediatR;

namespace Basket.Api.Commands
{
    public class AddBasketItemCommand : IRequest<BasketItemModel>
    {
        public int BasketId { get; set; }
        public BasketItemModel Item { get; set; }
    }
}
