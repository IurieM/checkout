using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Basket.Data.DbContexts;
using Basket.Api.Commands;
using Microsoft.EntityFrameworkCore;
using Basket.Api.Models;
using System.Linq;

namespace Identity.Api.Commands
{
    public class ClearBasketCommandHandler : IRequestHandler<ClearBasketCommand, BasketModel>
    {
        private readonly IBasketDbContext dbContext;

        public ClearBasketCommandHandler(IBasketDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BasketModel> Handle(ClearBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await dbContext.Baskets.Include(b => b.BasketItems).SingleOrDefaultAsync(b => b.Id == request.BasketId);
            basket.ClearBasketItems();
            await dbContext.SaveChangesAsync();
            return new BasketModel() { Id = basket.Id, BasketItems = basket.BasketItems.Select(i => new BasketItemModel()) };
        }
    }
}
