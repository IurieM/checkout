using System.Collections.Generic;
using System.Linq;

namespace Basket.Data.Entities
{
    public class UserBasket : Entity
    {
        public List<BasketItem> BasketItems { get; private set; }
        public int UserId { get; set; }

        public void DeleteItem(int itemId)
        {
            BasketItems.RemoveAll(b => b.Id == itemId);
        }

        public void AddItem(BasketItem item)
        {
            if (BasketItems == null)
            {
                BasketItems = new List<BasketItem>();
            }
            BasketItems.Add(item);
        }

        public BasketItem SetUnits(int itemId, int units)
        {
            if (BasketItems == null)
            {
                return null;
            }
            var item = BasketItems.FirstOrDefault(b => b.ItemId == itemId);
            item.Units = units;
            return item;
        }

        public void ClearBasketItems()
        {
            if (BasketItems == null)
            {
                return;
            }

            BasketItems.Clear();
        }
    }
}
