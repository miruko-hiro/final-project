using FinalProject.Architecture.DamageText.Scripts;
using FinalProject.Architecture.Scenes.MainMenu.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Installer
{
    public class FreeZoneInstaller : MonoInstaller
    {
        [SerializeField] private DamageTextManager _damageTextManager;
        [SerializeField] private SoundEffectsButtons _soundEffectsButtons;
        public override void InstallBindings()
        {
            Container.Bind<SoundEffectsButtons>().FromInstance(_soundEffectsButtons).AsSingle();
            Container.Bind<DamageTextManager>().FromInstance(_damageTextManager).AsSingle();
        }
    }
}