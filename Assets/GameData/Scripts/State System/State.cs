using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class State : ScriptableObject
    {
        [SerializeField] private State[] _states;

        public IEnumerable<State> States
        {
            get
            {
                foreach (State state in _states)
                    yield return state;
            }
        }

        public virtual void Construct() { }

        public virtual void Enter() { }

        public virtual void Tick() { }
        public virtual void PhysicTick() { }

        public void Exit() { }

        public virtual bool CheckCondition() { return true; }
    }
}
