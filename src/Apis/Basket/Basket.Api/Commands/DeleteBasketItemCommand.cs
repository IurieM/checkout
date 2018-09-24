using MediatR;

namespace Basket.Api.Commands
{
    public class DeleteBasketItemCommand : IRequest<int>
    {
        public int BasketId { get; set; }
        public int ItemId { get; set; }
    }
}
