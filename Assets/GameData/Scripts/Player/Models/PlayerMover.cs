using UnityEngine;
using Enigmatic.Experimental.Eniject;

namespace Gameplay
{
    public class PlayerMover
    {
        private PlayerInputHandler _inputHandler;
        private CharacterController _characterController;

        private Transform Transform => _characterController.transform;

        public PlayerMover(CharacterController characterController)
        {
            _inputHandler = GlobalContainer.Get<PlayerInputHandler>();
            _characterController = characterController;
        }

        public void Move(float speed)
        {
            Vector2 inputDirection = _inputHandler.GetMoveDirection();
            Vector3 direction = Transform.forward * inputDirection.y + Transform.right * inputDirection.x;
            direction = direction.normalized;

            _characterController.Move(direction * speed * Time.deltaTime);
        }
    }
}