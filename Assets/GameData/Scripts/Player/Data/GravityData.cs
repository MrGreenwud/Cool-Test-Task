using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public struct GravityData
    {
        [SerializeField] private float _gravityScale;
        [SerializeField] private float _groundCheckerRadius;
        [SerializeField] private float _groundCheckerOffset;
        [SerializeField] private float _distanceToGround;
        [SerializeField] private LayerMask _groundLayers;

        public float GravityScale => _gravityScale;
        public float GroundCheckerRadius => _groundCheckerRadius;
        public float GroundCheckerOffset => _groundCheckerOffset;
        public float DistanceToGround => _distanceToGround;
        public LayerMask GroundLayers => _groundLayers;
    }
}