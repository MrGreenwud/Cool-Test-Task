using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "Player Fall", menuName = "State System/Player/Fall", order = 1)]
    public class PlayerFallState : BasePlayerState
    {
        public override void Tick()
        {
            base.Tick();

            PlayerController.PlayerGravity.Fall();
        }

        public override bool CheckCondition()
        {
            return StateConditions.IsGround == false;
        }
    }
}