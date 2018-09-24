using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Basket.Data.DbContexts;
using Basket.Api.Commands;
using Basket.Data.Entities;
using Basket.Api.Models;

namespace Identity.Api.Commands
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, BasketModel>
    {
        private readonly IBasketDbContext dbContext;

        public CreateBasketCommandHandler(IBasketDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BasketModel> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = new UserBasket()
            {
                UserId = request.UserId
            };

            var result = dbContext.Baskets.Add(basket);
            await dbContext.SaveChangesAsync();
            return new BasketModel()
            {
                Id = basket.Id,
            };
        }
    }
}
