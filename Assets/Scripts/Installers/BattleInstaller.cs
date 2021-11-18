using Battle.Enemy;
using Zenject;

namespace Installers
{
    public class BattleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GeneratorEnemyData>().AsSingle();
        }
    }
}