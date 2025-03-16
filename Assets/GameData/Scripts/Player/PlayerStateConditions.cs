using UnityEngine;
using Enigmatic.Experimental.Eniject;

namespace Gameplay
{
    public class PlayerStateConditions
    {
        private PlayerGravity _playerGravity;
        private PlayerInputHandler _inputHandler;

        public bool IsMove { get; private set; }
        public bool IsRun { get; private set; }
        public bool IsGround { get; private set; }

        public PlayerStateConditions(PlayerGravity playerGravity)
        {
            _inputHandler = GlobalContainer.Get<PlayerInputHandler>();
            _playerGravity = playerGravity;
        }

        public void UpdateConditions()
        {
            IsMove = _inputHandler.GetMoveDirection() != Vector2.zero;
            IsRun = _inputHandler.RunButtonPressed();
            IsGround = _playerGravity.CheckGround();
        }
    }
}