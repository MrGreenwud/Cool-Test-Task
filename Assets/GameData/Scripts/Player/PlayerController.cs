using UnityEngine;
using Enigmatic.Experimental.Eniject;

namespace Gameplay
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour, IConstructable
    {
        [SerializeField] private MoveData _moveData;

        [Space(10)]

        [SerializeField] private GravityData _gravityData;

        [Space(10)]

        [SerializeField] private StateProvider _stateProvider;

        private CharacterController _characterController;
        private StateMachine _stateMachine;

        public PlayerMover PlayerMover { get; private set; }
        public PlayerGravity PlayerGravity { get; private set; }
        public PlayerStateConditions StateConditions { get; private set; }

        public MoveData MoveData => _moveData;
        public GravityData GravityData => _gravityData;

        public void Construct()
        {
            _characterController = GetComponent<CharacterController>();
            PlayerMover = new PlayerMover(_characterController);
            PlayerGravity = new PlayerGravity(_characterController, _gravityData);
            
            StateConditions = new PlayerStateConditions(PlayerGravity);

            _stateMachine = new StateMachine();

            _stateProvider.Initialize();
            _stateMachine.SwitchState(_stateProvider.Find<IdlePlayerState>());
        }

        private void Update()
        {
            StateConditions.UpdateConditions();
            _stateMachine.Tick();
        }

        private void FixedUpdate()
        {
            _stateMachine.PhysicTick();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            //Ground Checker Sphere
            {
                Vector3 position = transform.position + Vector3.up * _gravityData.GroundCheckerOffset;

                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(position, GravityData.GroundCheckerRadius);
            }

        }
#endif
    }
}