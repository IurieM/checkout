using Catalog.Api.Models;
using MediatR;
using System.Collections.Generic;

namespace Catalog.Api.Queries
{
    public class ProductsByCategoryQuery : IRequest<List<ProductListModel>>
    {
        public string Category { get; set; }

        public ProductsByCategoryQuery(string category)
        {
            Category = category;
        }
    }
}
