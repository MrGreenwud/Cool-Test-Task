using System;
using System.Linq;
using System.Collections.Generic;

namespace Gameplay
{
    public class Storage
    {
        private IEnumerable<SlotModel> _slotModels;

        public Storage(IEnumerable<SlotModel> slotModels)
        {
            _slotModels = slotModels;
        }

        public bool AddItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (Contains(item))
                return false;

            SlotModel slot = FindFirstEmptySlot();

            if (slot == null)
                return false;

            slot.SetItem(item);
            return true;
        }

        public bool DropItem(SlotModel slotModel, out Item item)
        {
            if (slotModel == null)
                throw new ArgumentNullException("slotModel");

            item = null;

            if (_slotModels.Contains(slotModel) == false)
                return false;

            if (slotModel.Item == null)
                return false;

            item = slotModel.Item;
            slotModel.Clear();
            return true;
        }

        public bool Contains(Item item)
        {
            foreach (SlotModel slot in _slotModels)
            {
                if (ReferenceEquals(slot.Item, item))
                    return true;
            }

            return false;
        }

        private SlotModel FindFirstEmptySlot()
        {
            foreach (SlotModel slot in _slotModels)
            {
                if (slot.Item == null)
                    return slot;
            }

            return null;
        }
    }
}