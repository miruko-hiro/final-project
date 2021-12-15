using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Game.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Health
{
    public class HealthPlayerBarPresenter
    {
        private readonly HeathPlayerBarView _view;
        private readonly PlayerHealthInspector _healthInspector;

        
        public HealthPlayerBarPresenter(HeathPlayerBarView view, GameManager gameManager)
        {
            _view = view;

            _healthInspector = gameManager.GetInteractor<PlayerHealthInspector>();

            _view.ReduceHealth(1f, _healthInspector.MaxHealth, _healthInspector.MaxHealth);

            OnOpen();
        }

        private void OnOpen()
        {
            _healthInspector.ReduceHealthEvent += ReduceHealth;
            _healthInspector.ChangeHealthEvent += ChangeHealthEvent;
        }

        private void ReduceHealth(int otherHealth)
        {
            var amount = (float) otherHealth / _healthInspector.MaxHealth;
            _view.ReduceHealth(amount, otherHealth, _healthInspector.MaxHealth);
        }

        private void ChangeHealthEvent(int otherHealth)
        {
            var amount = (float) _healthInspector.Health / otherHealth;
            _view.ChangeHealthEvent(amount, _healthInspector.Health, otherHealth);
        }

        private void OnClose()
        {
            _healthInspector.ReduceHealthEvent -= ReduceHealth;
            _healthInspector.ChangeHealthEvent -= ChangeHealthEvent;
        }

        ~HealthPlayerBarPresenter()
        {
            OnClose();
        }
    }
}