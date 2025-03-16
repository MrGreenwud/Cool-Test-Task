using UnityEngine;
using Enigmatic.Experimental.Eniject;

namespace Gameplay.DI
{
    public class PlayerInventoryInstaller : SceneInstaller
    {
        [SerializeField] private PlayerInventory _inventory;

        public override void Install(SceneContainer container)
        {
            base.Install(container);

            container.RegisterInstance(_inventory);
        }
    }
}