using UnityEngine;
using Enigmatic.Experimental.Eniject;

namespace Gameplay.DI
{
    public class InteractReyCasterInstaller : SceneInstaller
    {
        public override void Install(SceneContainer container)
        {
            base.Install(container);

            InteractReyCaster reyCaster = GlobalContainer.Get<PlayerController>().gameObject
                .GetComponentInChildren<InteractReyCaster>();
            container.RegisterInstance(reyCaster);
        }
    }
}