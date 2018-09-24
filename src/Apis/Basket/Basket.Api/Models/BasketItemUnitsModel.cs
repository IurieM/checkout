namespace Basket.Api.Models
{
    public class BasketItemUnitsModel
    {
        public int ItemId { get; set; }
        public int Units { get; set; }

        public BasketItemUnitsModel(int itemId, int units)
        {
            ItemId = itemId;
            Units = units;
        }
    }
}
