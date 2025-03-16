using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public struct MoveData
    {
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _runSpeed;

        public float WalkSpeed => _walkSpeed;
        public float RunSpeed => _runSpeed;
    }
}