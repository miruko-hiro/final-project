using PlayerCreation.UI;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Installer
{
    public class PlayerCreationInstaller : MonoInstaller
    {
        [SerializeField] private UIManager uiManager;
        public override void InstallBindings()
        {
            Container.Bind<UIManager>().FromInstance(uiManager).AsSingle();
        }
    }
}