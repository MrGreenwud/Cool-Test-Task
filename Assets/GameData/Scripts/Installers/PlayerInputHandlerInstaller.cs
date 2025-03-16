using UnityEngine;
using Enigmatic.Experimental.Eniject;

namespace Gameplay.DI
{
    public class PlayerInputHandlerInstaller : SceneInstaller
    {
        [SerializeField] private PlayerInputHandler _playerInputHandler;

        public override void Install(SceneContainer container)
        {
            base.Install(container);

            container.RegisterInstance(_playerInputHandler);
        }
    }
}