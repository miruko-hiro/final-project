using FinalProject.Architecture.DamageText;
using FinalProject.Architecture.DamageText.Scripts;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Items.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Installer
{
    public class BattleInstaller : MonoInstaller
    {
        [SerializeField] private ItemManager _itemManager;
        [SerializeField] private DamageTextManager _damageTextManager;
        public override void InstallBindings()
        {
            Container.Bind<PrefabFactory>().AsSingle();
            Container.Bind<InjectionClassFactory>().AsSingle();
            
            Container.Bind<ItemManager>().FromInstance(_itemManager).AsSingle();
            Container.QueueForInject(_itemManager);
            
            Container.Bind<DamageTextManager>().FromInstance(_damageTextManager).AsSingle();
        }
    }
}