using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Game.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Health
{
    public class HealthPlayerBarPresenter
    {
        private readonly HeathPlayerBarView _view;
        private readonly PlayerHealthInspector _healthInspector;
        private int _maxHealth;

        
        public HealthPlayerBarPresenter(HeathPlayerBarView view, GameManager gameManager)
        {
            _view = view;

            _healthInspector = gameManager.GetInteractor<PlayerHealthInspector>();
            _maxHealth = _healthInspector.Health;

            _view.ReduceHealth(1f, _maxHealth, _maxHealth);

            OnOpen();
        }

        private void OnOpen()
        {
            _healthInspector.ReduceHealthEvent += ReduceHealth;
            _healthInspector.IncreaseHealthEvent += IncreaseHealth;
        }

        private void ReduceHealth(int otherHealth)
        {
            var amount = (float) otherHealth / _maxHealth;
            _view.ReduceHealth(amount, otherHealth, _maxHealth);
        }

        private void IncreaseHealth(int otherHealth)
        {
            _maxHealth = otherHealth;
            _view.IncreaseHealth(otherHealth, _maxHealth);
        }

        private void OnClose()
        {
            _healthInspector.ReduceHealthEvent -= ReduceHealth;
            _healthInspector.IncreaseHealthEvent -= IncreaseHealth;
        }

        ~HealthPlayerBarPresenter()
        {
            OnClose();
        }
    }
}