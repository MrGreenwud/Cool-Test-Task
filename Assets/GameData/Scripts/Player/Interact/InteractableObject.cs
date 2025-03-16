using UnityEngine;

namespace Gameplay
{
    public class InteractableObject : MonoBehaviour
    {
        public virtual bool Interact() { return false; }

        public virtual bool Interact(Item item) { return false; }
    }
}