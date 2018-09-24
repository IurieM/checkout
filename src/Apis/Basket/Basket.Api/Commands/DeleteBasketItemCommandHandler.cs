using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Basket.Data.DbContexts;
using Basket.Api.Commands;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Commands
{
    public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommand, int>
    {
        private readonly IBasketDbContext dbContext;

        public DeleteBasketItemCommandHandler(IBasketDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basket = await dbContext.Baskets.Include(b => b.BasketItems).SingleOrDefaultAsync(b => b.Id == request.BasketId);
            basket.DeleteItem(request.ItemId);
            await dbContext.SaveChangesAsync();
            return request.ItemId;
        }
    }
}
