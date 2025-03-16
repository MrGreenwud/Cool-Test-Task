using UnityEngine;

namespace Gameplay
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _followSpeed = 9.0f;
        [SerializeField] private float _rotateSpeed = 9.0f;
        [SerializeField] private Transform _target;

        private void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, _followSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, _target.rotation, _rotateSpeed * Time.deltaTime);
        }
    }
}
