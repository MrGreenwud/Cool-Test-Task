using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "Player Walk", menuName = "State System/Player/Walk", order = 2)]
    public class WalkPlayerState : BasePlayerState
    {
        public override void Tick()
        {
            base.Tick();

            PlayerController.PlayerMover.Move(PlayerController.MoveData.WalkSpeed);
        }

        public override bool CheckCondition()
        {
            return StateConditions.IsGround && StateConditions.IsMove 
                && StateConditions.IsRun == false;
        }
    }
}