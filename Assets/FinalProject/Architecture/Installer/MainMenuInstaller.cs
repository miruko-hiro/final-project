using FinalProject.Architecture.Scenes.MainMenu.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Installer
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private SoundEffectsButtons _soundEffectsButtons;
        public override void InstallBindings()
        {
            Container.Bind<SoundEffectsButtons>().FromInstance(_soundEffectsButtons).AsSingle();
        }
    }
}