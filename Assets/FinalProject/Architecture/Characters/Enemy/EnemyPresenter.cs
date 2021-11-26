using FinalProject.Architecture.Characters.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Enemy
{
    public class EnemyPresenter
    {
        private readonly EnemyView _view;
        private readonly EnemyData _model;

        public EnemyPresenter(EnemyView view, EnemyData model)
        {
            _view = view;
            _model = model;
            OnOpen();
        }

        private void OnOpen()
        {
            _model.Health.Change += Die;
            _view.OnTakeDamageEvent += ChangeHealth;
        }

        private void Die(int health)
        {
            if (health > 0) return;
            OnClose();
            _view.Die();
        }

        private void ChangeHealth(int damage)
        {
            _model.Health.Value -= damage;
        }

        private void OnClose()
        {
            _model.Health.Change -= Die;
            _view.OnTakeDamageEvent -= ChangeHealth;
        }

        ~EnemyPresenter()
        {
            OnClose();
        }
    }
}