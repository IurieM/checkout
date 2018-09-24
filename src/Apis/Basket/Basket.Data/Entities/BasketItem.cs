namespace Basket.Data.Entities
{
    public class BasketItem : Entity
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Units { get; set; }
    }
}
