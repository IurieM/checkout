using Catalog.Data.Entities;
using System.Collections.Generic;

namespace Catalog.Data.Seed
{
    public static class CatalogSeed
    {
        public static IEnumerable<Category> Categories => new List<Category>()
        {
            new Category()
            {
                Name = "Laptop",
                Description = "Laptop",
                Products = new List<Product>()
                {
                   new Product()
                   {
                        Name ="Asus ZenBook UX430UA",
                        Description ="Intel Core Kaby Lake R (8th Gen) i7-8550U 256GB 8GB Win10 Pro FullHD FPR Gri UX430UA-GV271R",
                        AvailableStock = 5,
                        Price = 751
                   },
                   new Product()
                   {
                        Name ="Asus ZenBook Flip UX461U",
                        Description ="Intel Core Kaby Lake R (8th Gen) i7-8550U 256GB 8GB Win10 FullHD FPR husa+stylus ux461ua-e1014t",
                        AvailableStock = 4,
                        Price = 651
                   },
                   new Product()
                   {
                        Name ="Ultrabook Lenovo X1",
                        Description ="Carbon Gen 6 Intel Core Kaby Lake R (8th Gen) i7-8550U 1TB SSD 16GB Win10 Pro WideQHD 20kh006mri",
                        AvailableStock = 6,
                        Price = 851
                   }
                }
            }
        };
    }
}
