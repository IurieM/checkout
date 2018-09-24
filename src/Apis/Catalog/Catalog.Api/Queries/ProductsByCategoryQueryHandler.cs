using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Catalog.Data.DbContexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Catalog.Api.Models;
using System.Collections.Generic;
using System;

namespace Catalog.Api.Queries
{
    public class ProductsByCategoryQueryHandler : IRequestHandler<ProductsByCategoryQuery, List<ProductListModel>>
    {
        private readonly ICatalogDbContext productContext;

        public ProductsByCategoryQueryHandler(ICatalogDbContext productContext)
        {
            this.productContext = productContext;
        }

        public Task<List<ProductListModel>> Handle(ProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            return productContext.Products
                .Where(p => string.Equals(p.Category.Name, request.Category, StringComparison.InvariantCultureIgnoreCase))
                .Select(p => new ProductListModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    AvailableStock = p.AvailableStock,
                    Description = p.Description,
                    Price = p.Price
                }).ToListAsync();
        }
    }
}
