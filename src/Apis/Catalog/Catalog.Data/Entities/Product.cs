﻿namespace Catalog.Data.Entities
{
    public class Product:Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int AvailableStock { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
