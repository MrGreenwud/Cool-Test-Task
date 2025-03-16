using UnityEngine;
using Enigmatic.Experimental.Eniject;

namespace Gameplay
{
    public class ItemPickier : MonoBehaviour, IConstructable
    {
        private PlayerInputHandler _playerInputHandler;
        private PlayerInventory _playerInventory;

        public void Construct()
        {
            _playerInputHandler = GlobalContainer.Get<PlayerInputHandler>();
            _playerInventory = GlobalContainer.Get<PlayerInventory>();
            GlobalContainer.Get<InteractReyCaster>().OnHit += Pickup;
        }

        private void Pickup(GameObject gameObject)
        {
            if (_playerInputHandler.InteractButtonDown() == false)
                return;

            if (gameObject.TryGetComponent(out ItemObject component) == false)
                return;

            if (_playerInventory.AddItem(component.Item) == false)
                return;

            Destroy(gameObject);
        }
    }
}
