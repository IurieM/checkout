using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Basket.Data.DbContexts;
using Basket.Api.Commands;
using Basket.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Identity.Api.Commands
{
    public class GetUserBasketQueryHandler : IRequestHandler<GetUserBasketQuery, BasketModel>
    {
        private readonly IBasketDbContext dbContext;

        public GetUserBasketQueryHandler(IBasketDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<BasketModel> Handle(GetUserBasketQuery request, CancellationToken cancellationToken)
        {
            return dbContext.Baskets.Select(b => new BasketModel()
            {
                Id = b.Id,
                BasketItems = b.BasketItems.Select(i => new BasketItemModel()
                {
                    ItemId = i.ItemId,
                    Name = i.Name,
                    Price = i.Price,
                    Units = i.Units
                })
            }).SingleOrDefaultAsync();
        }
    }
}
