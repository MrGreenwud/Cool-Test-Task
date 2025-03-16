using Enigmatic.Experimental.Eniject;
using UnityEngine;

namespace Gameplay
{
    public class Interactor : MonoBehaviour, IConstructable
    {
        private SlotSelector _slotSelector;
        private PlayerInputHandler _playerInputHandler;

        public void Construct()
        {
            _slotSelector = GlobalContainer.Get<SlotSelector>();
            _playerInputHandler = GlobalContainer.Get<PlayerInputHandler>();
            GlobalContainer.Get<InteractReyCaster>().OnHit += Interact;
        }

        public void Interact(GameObject gameObject)
        {
            if (_playerInputHandler.InteractButtonDown() == false)
                return;

            if (gameObject.TryGetComponent(out InteractableObject component) == false)
                return;

            if (component.Interact() == false)
                component.Interact(_slotSelector.SelectedSlot.Model.Item);
        }
    }
}
