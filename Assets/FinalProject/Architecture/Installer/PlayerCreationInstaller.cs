using FinalProject.Architecture.Scenes.MainMenu.Scripts;
using FinalProject.Architecture.Scenes.PlayerCreation.Scripts.UI;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Installer
{
    public class PlayerCreationInstaller : MonoInstaller
    {
        [SerializeField] private UIManager uiManager;
        [SerializeField] private SoundEffectsButtons _soundEffectsButtons;
        public override void InstallBindings()
        {
            Container.Bind<UIManager>().FromInstance(uiManager).AsSingle();
            Container.Bind<SoundEffectsButtons>().FromInstance(_soundEffectsButtons).AsSingle();
        }
    }
}