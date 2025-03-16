using UnityEngine;
using Utility;

namespace Gameplay
{
    public class ItemObject : MonoBehaviour
    {
        [SerializeField] private Item _item;

        public Item Item => _item;

        private void Awake()
        {
            _item = _item.CloneInstance();
        }

        public void SetItem(Item item)
        {
            if (item == null)
                throw new System.ArgumentException("item");

            _item = item;
        }
    }
}