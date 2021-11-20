using FinalProject.Architecture.Characters.Player;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Helpers.Scripts;
using Template.Creatures.Appearance;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Installer
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private AppearanceIssuanceSystem appearanceIssuanceSystem;
        
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().AsSingle();
            
            Container.Bind<ExitHelper>().AsSingle();
            Container.Bind<GameStateHelper>().AsSingle();
            Container.Bind<InjectionClassFactory>().AsSingle();
            Container.Bind<PrefabFactory>().AsSingle();
            
            Container.Bind<PlayerData>().AsSingle();
            Container.Bind<AppearanceIssuanceSystem>().FromInstance(appearanceIssuanceSystem).AsSingle();

            Container.Bind<Coroutines>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
            Container.Bind<GameStateManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}