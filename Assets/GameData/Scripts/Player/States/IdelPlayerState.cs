using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "Player Idle", menuName = "State System/Player/Idle", order = 0)]
    public class IdlePlayerState : BasePlayerState
    {
        public override bool CheckCondition()
        {
            return StateConditions.IsGround && StateConditions.IsMove == false;
        }
    }
}