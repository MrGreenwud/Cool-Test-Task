using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "State Provider", menuName = "State System/Provider")]
    public class StateProvider : ScriptableObject
    {
        [SerializeField] private State[] _states;

        private Dictionary<State, State> _stateInstances;

        public void Initialize()
        {
            _stateInstances = new Dictionary<State, State>();

            foreach (State state in _states)
            {
                State instance = state.CloneInstance();
                _stateInstances.Add(state, instance);
                instance.Construct();
            }

            foreach (State state in _stateInstances.Values)
            {
                FieldInfo field = typeof(State).GetField("_states", BindingFlags.NonPublic | BindingFlags.Instance);
                object value = field.GetValue(state);

                State[] states = value as State[];
                State[] newStateArray = new State[states.Length];

                for (int i = 0; i < states.Length; i++)
                    newStateArray[i] = Get(states[i]);

                field.SetValue(state, newStateArray);
            }
        }

        public T Get<T>(T state) where T : State
        {
            return (T)_stateInstances[state];
        }

        public T Find<T>() where T : State
        {
            foreach (State state in _stateInstances.Values)
            {
                if (state is T result)
                    return result;
            }

            return null;
        }
    }
}