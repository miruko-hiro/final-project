using FinalProject.Architecture.Characters.Enemy;
using FinalProject.Architecture.UI.Scripts;

namespace FinalProject.Architecture.Health
{
    public class HealthEnemyBarPresenter
    {
        private readonly HealthBar _view;
        private readonly EnemyData _model;
        private readonly int _maxHealth;

        public HealthEnemyBarPresenter(HealthBar view, EnemyData model)
        {
            _view = view;
            _model = model;
            _maxHealth = model.Health.Value;

            OnOpen();
        }

        private void OnOpen()
        {
            _model.Health.Change += ChangeHealth;
        }

        private void ChangeHealth(int otherHealth)
        {
            if (otherHealth > 0)
            {
                var amount = (float) otherHealth / _maxHealth;
                _view.ReduceHealth(amount);
            }
            else
            {
                OnClose();
                UnityEngine.Object.Destroy(_view.gameObject);
            }
        }

        private void OnClose()
        {
            _model.Health.Change -= ChangeHealth;
        }

        ~HealthEnemyBarPresenter()
        {
            OnClose();
        }
    }
}