using UnityEngine;

namespace Gameplay
{
    public class PlayerGravity
    {
        private CharacterController _characterController;
        private GravityData _gravityData;

        public PlayerGravity(CharacterController characterController, GravityData gravityData)
        {
            _characterController = characterController;
            _gravityData = gravityData;
        }

        public void Fall()
        {
            Vector3 fallVelocity = Vector3.down * _gravityData.GravityScale * Time.deltaTime;
            
            Vector3 horizontalVelocity = _characterController.velocity;
            horizontalVelocity.y = 0;

            _characterController.Move(fallVelocity + horizontalVelocity * Time.deltaTime);
        }

        public bool CheckGround()
        {
            Vector3 position = _characterController.transform.position 
                + Vector3.up * _gravityData.GroundCheckerOffset;

            return Physics.SphereCast(
                position,
                _gravityData.GroundCheckerRadius,
                Vector3.down,
                out RaycastHit hit,
                _gravityData.DistanceToGround,
                _gravityData.GroundLayers);
        }
    }
}
