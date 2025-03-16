using System;
using UnityEngine;

namespace Gameplay
{
    public class InteractReyCaster : MonoBehaviour
    {
        [SerializeField] private float _maxDistance;
        [SerializeField] private LayerMask _interactableLayers;

        public Action<GameObject> OnHit;

        private void Update()
        {
            if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 
                _maxDistance, _interactableLayers))
            {
                OnHit?.Invoke(hit.collider.gameObject);
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * _maxDistance);
        }
#endif
    }
}
