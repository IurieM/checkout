namespace Basket.Api.Models
{
    public class BasketItemModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Units { get; set; }
    }
}
