using System;

namespace Gameplay
{
    public class SlotModel
    {
        public Item Item { get; private set; }

        public Action<Item> OnItemChanged;

        public void SetItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (item == Item)
                return;

            Item = item;
            OnItemChanged?.Invoke(Item);
        }

        public void Clear()
        {
            Item = null;
            OnItemChanged?.Invoke(Item);
        }
    }
}