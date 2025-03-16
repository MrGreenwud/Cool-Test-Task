using Enigmatic.Experimental.Eniject;

namespace Gameplay
{
    public class BasePlayerState : State
    {
        protected PlayerController PlayerController { get; private set; }
        protected PlayerStateConditions StateConditions => PlayerController.StateConditions;

        public override void Construct()
        {
            base.Construct();

            PlayerController = GlobalContainer.Get<PlayerController>();
        }
    }
}