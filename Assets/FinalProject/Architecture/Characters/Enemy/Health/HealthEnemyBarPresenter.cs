using FinalProject.Architecture.Characters.Scripts;
using FinalProject.Architecture.UI.Scripts;

namespace FinalProject.Architecture.Characters.Enemy.Health
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