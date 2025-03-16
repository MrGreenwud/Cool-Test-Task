using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private Slot[] _hotBarSlots;

        public IEnumerable<Slot> HotBarSlots
        {
            get
            {
                foreach (Slot slot in _hotBarSlots)
                    yield return slot;
            }
        }
        public IEnumerable<SlotModel> HotBarSlotModels
        {
            get
            {
                foreach (Slot slot in _hotBarSlots)
                    yield return slot.Model;
            }
        }

        private Storage _hotBar;

        public void Awake()
        {
            _hotBar = new Storage(HotBarSlotModels);
        }

        public bool AddItem(Item item)
        {
            return _hotBar.AddItem(item);
        }

        public bool DropItem(Slot slot, out Item item)
        {
            return _hotBar.DropItem(slot.Model, out item);
        }
    }
}
