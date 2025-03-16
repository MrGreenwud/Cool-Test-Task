using UnityEngine;
using Enigmatic.Experimental.Eniject;

namespace Gameplay
{
    public class SlotSelector : MonoBehaviour, IConstructable
    {
        [SerializeField] private float _selectorMoveSpeed;

        public Slot LastSelectedSlot { get; private set; }
        public Slot SelectedSlot { get; private set; }

        public SlotSelectorModel Model { get; private set; }
        public SlotSelectorView View { get; private set; }

        public void Construct()
        {
            Model = new SlotSelectorModel();
            View = new SlotSelectorView(transform, _selectorMoveSpeed);

            Model.ChangeSelectedSlot += SelectSlot;
            Model.ChangeSelectedSlot += View.OnChangeSelectedSlot;

            Model.Init();
        }

        private void Update()
        {
            Model.Update();
            View.Update();
        }

        private void SelectSlot(Slot slot)
        {
            LastSelectedSlot = SelectedSlot;
            SelectedSlot = slot;
        }
    }
}