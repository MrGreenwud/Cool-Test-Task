using System;
using System.Linq;
using Enigmatic.Experimental.Eniject;
using Utility;

namespace Gameplay
{
    public class SlotSelectorModel
    {
        private PlayerInventory _inventory;
        private PlayerInputHandler _inputHandler;

        public int SlotIndex { get; private set; }

        public Action<Slot> ChangeSelectedSlot;

        public SlotSelectorModel()
        {
            _inventory = GlobalContainer.Get<PlayerInventory>();
            _inputHandler = GlobalContainer.Get<PlayerInputHandler>();
        }

        public void Init()
        {
            ChangeSelectedSlot?.Invoke(_inventory.HotBarSlots.GetElementByIndex(0));
        }

        public void Update()
        {
            if (_inputHandler.HotBarScrollDirection() != 0)
            {
                SlotIndex += _inputHandler.HotBarScrollDirection();

                if (SlotIndex > _inventory.HotBarSlots.Count() - 1)
                    SlotIndex = 0;
                else if (SlotIndex < 0)
                    SlotIndex = _inventory.HotBarSlots.Count() - 1;

                ChangeSelectedSlot?.Invoke(_inventory.HotBarSlots.GetElementByIndex(SlotIndex));
            }
            else if (_inputHandler.HotBarNumeric() != -1)
            {
                SlotIndex = _inputHandler.HotBarNumeric();
                SlotIndex = Math.Clamp(SlotIndex, 0, _inventory.HotBarSlots.Count() - 1);
                ChangeSelectedSlot?.Invoke(_inventory.HotBarSlots.GetElementByIndex(SlotIndex));
            }
        }
    }
}
