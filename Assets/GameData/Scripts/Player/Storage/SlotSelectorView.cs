using UnityEngine;

namespace Gameplay
{
    public class SlotSelectorView
    {
        private Transform _transform;
        private float _selectorMoveSpeed;
        private Transform _target;

        public SlotSelectorView(Transform transform, float selectorMoveSpeed)
        {
            _transform = transform;
            _selectorMoveSpeed = selectorMoveSpeed;
        }

        public void OnChangeSelectedSlot(Slot slot)
        {
            _target = slot.transform;
        }

        public void Update()
        {
            if (_target == null)
                return;

            _transform.position = Vector3.Lerp(_transform.position, 
                _target.position, _selectorMoveSpeed * Time.deltaTime);
        }
    }
}
