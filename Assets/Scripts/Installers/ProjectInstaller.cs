using Core.Helpers;
using Core.Player;
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
            Container.Bind<ExitHelper>().AsSingle();
            Container.Bind<GameStateHelper>().AsSingle();
            Container.Bind<InjectionObjectFactory>().AsSingle();
            Container.Bind<PrefabFactory>().AsSingle();
            
            Container.Bind<PlayerData>().AsSingle();
            Container.Bind<AppearanceIssuanceSystem>().FromInstance(appearanceIssuanceSystem).AsSingle();
        }
    }
}