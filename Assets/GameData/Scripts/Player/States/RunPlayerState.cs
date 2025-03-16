using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "Player Run", menuName = "State System/Player/Run", order = 3)]
    public class RunPlayerState : BasePlayerState
    {
        public override void Tick()
        {
            base.Tick();

            PlayerController.PlayerMover.Move(PlayerController.MoveData.RunSpeed);
        }

        public override bool CheckCondition()
        {
            return StateConditions.IsGround && StateConditions.IsMove 
                && StateConditions.IsRun;
        }
    }
}
