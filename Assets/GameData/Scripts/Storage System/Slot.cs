using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public SlotModel Model { get; private set; }
        public ISlotView View { get; private set; }

        public void Awake()
        {
            Model = new SlotModel();
            View = new SlotView(_image);

            Model.OnItemChanged += View.Update;
        }
    }
}