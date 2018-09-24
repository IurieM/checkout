using System.Collections.Generic;

namespace Basket.Api.Models
{
    public class BasketModel
    {
        public int Id { get; set; }
        public IEnumerable<BasketItemModel> BasketItems { get; set; }

        public BasketModel()
        {
            BasketItems = new List<BasketItemModel>();
        }
    }
}
