using FinalProject.Architecture.UI.Scripts;

namespace FinalProject.Architecture.Characters.Enemy.Health
{
    public class HealthEnemyBarPresenter
    {
        private readonly HealthBar _view;
        private readonly EnemyData _model;

        public HealthEnemyBarPresenter(HealthBar view, EnemyData model)
        {
            _view = view;
            _model = model;
        }
    }
}