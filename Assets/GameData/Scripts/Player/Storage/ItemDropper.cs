using Enigmatic.Experimental.Eniject;
using UnityEngine;

namespace Gameplay
{
    public class ItemDropper : MonoBehaviour, IConstructable
    {
        [SerializeField] private Transform _itemSpawnPoint;
        [SerializeField] private float _dropForce;

        private PlayerInputHandler _inputHandler;
        private SlotSelector _slotSelector;
        private PlayerInventory _inventory;
        private Transform _transform;

        public void Construct()
        {
            _inputHandler = GlobalContainer.Get<PlayerInputHandler>();
            _slotSelector = GlobalContainer.Get<SlotSelector>();
            _inventory = GlobalContainer.Get<PlayerInventory>();
            _transform = GlobalContainer.Get<InteractReyCaster>().transform;
        }

        private void Update()
        {
            if(_inputHandler.DropButtonDown())
            Drop();
        }

        private void Drop()
        {
            if (_inventory.DropItem(_slotSelector.SelectedSlot, out Item item) == false)
                return;

            GameObject gameObject = Instantiate(item.Prefab, _transform.position, Quaternion.identity);
            ItemObject itemObject = gameObject.GetComponent<ItemObject>();
            itemObject.SetItem(item);
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(_transform.forward * _dropForce, ForceMode.Impulse);
        }
    }
}
