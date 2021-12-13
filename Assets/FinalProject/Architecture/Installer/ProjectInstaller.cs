using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Settings.Music;
using FinalProject.Architecture.Settings.SoundEffects;
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
            
            Container.Bind<AppearanceIssuanceSystem>().FromInstance(appearanceIssuanceSystem).AsSingle();

            Container.Bind<Coroutines>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
            Container.Bind<MusicManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
            Container.Bind<MusicCollection>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
            Container.Bind<SoundEffectsManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
            Container.Bind<SoundEffectsCollection>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}