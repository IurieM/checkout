using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Basket.Data.DbContexts;
using Basket.Api.Commands;
using Basket.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Commands
{
    public class SetBasketItemUnitsCommandHandler : IRequestHandler<SetBasketItemUnitsCommand, BasketItemUnitsModel>
    {
        private readonly IBasketDbContext dbContext;

        public SetBasketItemUnitsCommandHandler(IBasketDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BasketItemUnitsModel> Handle(SetBasketItemUnitsCommand request, CancellationToken cancellationToken)
        {
            var basket = await dbContext.Baskets.Include(b => b.BasketItems).SingleOrDefaultAsync(b => b.Id == request.BasketId);
            var basketItem = basket.SetUnits(request.ItemId, request.Units);

            await dbContext.SaveChangesAsync();
            return new BasketItemUnitsModel(basketItem.ItemId, basketItem.Units);
        }
    }
}
