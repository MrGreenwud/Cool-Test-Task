using UnityEngine;

namespace Gameplay
{
    public class Door : InteractableObject
    {
        [SerializeField] private float _openAngle;
        [SerializeField] private float _closeAngle;
        [SerializeField] private float _openCloseSpeed;

        [SerializeField] private bool _isLock;

        private bool _isOpen;
        private Quaternion _openRotation;
        private Quaternion _closeRotation;

        private float _t;

        private void Awake()
        {
            _openRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, _openAngle);
            _closeRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, _closeAngle);
        }

        private void Update()
        {
            if (_t >= 1)
                return;

            _t += _openCloseSpeed * Time.deltaTime;

            if(_isOpen)
                transform.localRotation = Quaternion.Slerp(transform.localRotation, _openRotation, _t);
            else
                transform.localRotation = Quaternion.Slerp(transform.localRotation, _closeRotation, _t);
        }

        public override bool Interact()
        {
            if (_isLock == true)
                return false;

            if (_isOpen)
                Close();
            else
                Open();

            return true;
        }

        public override bool Interact(Item item)
        {
            if (item == null)
                return false;

            if (item is Key key == false)
                return false;

            Unlock();
            Interact();

            return true;
        }

        public void Open()
        {
            _isOpen = true;
            _t = 0;
        }

        public void Close()
        {
            _isOpen = false;
            _t = 0;
        }

        public void Lock()
        {
            _isLock = true;
        }

        public void Unlock()
        {
            _isLock = false;
        }
    }
}
