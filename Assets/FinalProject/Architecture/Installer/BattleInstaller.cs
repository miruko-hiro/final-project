using FinalProject.Architecture.DamageText;
using FinalProject.Architecture.DamageText.Scripts;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Items.Scripts;
using FinalProject.Architecture.Scenes.MainMenu.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Installer
{
    public class BattleInstaller : MonoInstaller
    {
        [SerializeField] private ItemManager _itemManager;
        [SerializeField] private DamageTextManager _damageTextManager;
        [SerializeField] private SoundEffectsButtons _soundEffectsButtons;
        public override void InstallBindings()
        {
            Container.Bind<PrefabFactory>().AsSingle();
            Container.Bind<InjectionClassFactory>().AsSingle();
            
            Container.Bind<ItemManager>().FromInstance(_itemManager).AsSingle();
            Container.QueueForInject(_itemManager);
            
            Container.Bind<DamageTextManager>().FromInstance(_damageTextManager).AsSingle();
            Container.Bind<SoundEffectsButtons>().FromInstance(_soundEffectsButtons).AsSingle();
        }
    }
}