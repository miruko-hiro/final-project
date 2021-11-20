using Battle.Enemy;
using Zenject;

namespace FinalProject.Architecture.Installer
{
    public class BattleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GeneratorEnemyData>().AsSingle();
        }
    }
}