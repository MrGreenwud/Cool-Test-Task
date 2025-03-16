using System;

namespace Gameplay
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }

        public void SwitchState(State state)
        {
            if (state == null)
                throw new ArgumentNullException();

            if(CurrentState == state)
                throw new InvalidOperationException();

            if(CurrentState != null)
                CurrentState.Exit();

            CurrentState = state;
            CurrentState.Exit();
        }

        public void Tick()
        {
            if (CurrentState == null)
                return;

            foreach(State state in CurrentState.States)
            {
                if (state.CheckCondition())
                    SwitchState(state);
            }

            CurrentState.Tick();
        }

        public void PhysicTick()
        {
            if (CurrentState == null)
                return;

            CurrentState.PhysicTick();
        }
    }
}
