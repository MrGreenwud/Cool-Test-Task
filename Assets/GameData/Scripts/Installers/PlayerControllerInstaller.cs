using UnityEngine;
using Enigmatic.Experimental.Eniject;

namespace Gameplay.DI
{
    public class PlayerControllerInstaller : SceneInstaller
    {
        [SerializeField] private PlayerController _playerController;
        //[SerializeField] private PlayerSpawner _spawner;

        public override void Install(SceneContainer container)
        {
            base.Install(container);

            //PlayerController playerController = _spawner.Spawn();
            container.RegisterInstance(_playerController);
        }
    }
}
