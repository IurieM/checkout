using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Basket.Data.DbContexts;
using Basket.Api.Commands;
using Basket.Data.Entities;
using Basket.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Commands
{
    public class AddBasketItemCommandHandler : IRequestHandler<AddBasketItemCommand, BasketItemModel>
    {
        private readonly IBasketDbContext dbContext;

        public AddBasketItemCommandHandler(IBasketDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BasketItemModel> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basket = await dbContext.Baskets.SingleOrDefaultAsync(b => b.Id == request.BasketId);
            basket.AddItem(new BasketItem()
            {
                ItemId = request.Item.ItemId,
                Name = request.Item.Name,
                Price = request.Item.Price,
                Units = request.Item.Units
            });

            await dbContext.SaveChangesAsync();
            return request.Item;
        }
    }
}
