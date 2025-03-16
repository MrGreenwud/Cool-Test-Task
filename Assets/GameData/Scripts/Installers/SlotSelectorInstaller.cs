using UnityEngine;
using Enigmatic.Experimental.Eniject;

namespace Gameplay.DI
{
    public class SlotSelectorInstaller : SceneInstaller
    {
        [SerializeField] private SlotSelector _slotSelector;

        public override void Install(SceneContainer container)
        {
            base.Install(container);

            container.RegisterInstance(_slotSelector);
        }
    }
}