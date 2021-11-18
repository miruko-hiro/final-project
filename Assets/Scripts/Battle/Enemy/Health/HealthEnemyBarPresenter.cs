using Core.Interfaces;
using Core.UI;

namespace Battle.Enemy.Health
{
    public class HealthEnemyBarPresenter
    {
        private readonly HealthBar _view;
        private readonly ICharacterData _model;

        public HealthEnemyBarPresenter(HealthBar view, ICharacterData model)
        {
            _view = view;
            _model = model;
        }
    }
}