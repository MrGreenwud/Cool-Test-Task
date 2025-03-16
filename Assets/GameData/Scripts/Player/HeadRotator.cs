using UnityEngine;
using Enigmatic.Experimental.Eniject;

namespace Gameplay
{
    public class HeadRotator : MonoBehaviour
    {
        [SerializeField] private float _sensitivity;

        [Space(10)]

        [SerializeField] private float _maxRotationXClamp = 90;
        [SerializeField] private float _minRotationXClamp = -90;

        [Space(10)]

        [SerializeField] private Transform _body;

        private PlayerInputHandler _inputHandler;

        private float _xRotate;

        public void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _inputHandler = GlobalContainer.Get<PlayerInputHandler>();
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            float x = _inputHandler.GetHeadRotationDirection().x * _sensitivity * Time.deltaTime;
            float y = _inputHandler.GetHeadRotationDirection().y * _sensitivity * Time.deltaTime;

            _xRotate -= y;
            _xRotate = Mathf.Clamp(_xRotate, _minRotationXClamp, _maxRotationXClamp);

            transform.localRotation = Quaternion.Euler(_xRotate, 0, 0);
            _body.Rotate(Vector3.up * x);
        }
    }
}