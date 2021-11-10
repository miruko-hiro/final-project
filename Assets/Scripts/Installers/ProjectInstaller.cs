using Template.Creatures.Appearance;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private AppearanceIssuanceSystem appearanceIssuanceSystem;
        public override void InstallBindings()
        {
            Container.Bind<AppearanceIssuanceSystem>().FromInstance(appearanceIssuanceSystem).AsSingle();
        }
    }
}