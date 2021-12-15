using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Game.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Inventory
{
    public class CharacteristicPresenter
    {
        private readonly Characteristic _view;
        private readonly PlayerHealthInspector _healthInspector;
        private readonly PlayerAttackInteractor _attackInteractor;

        public CharacteristicPresenter(Characteristic view, GameManager gameManager)
        {
            _view = view;
            _healthInspector = gameManager.GetInteractor<PlayerHealthInspector>();
            _attackInteractor = gameManager.GetInteractor<PlayerAttackInteractor>();
            
            OnOpen();
        }

        private void OnLoad()
        {
            ChangeHealth(_healthInspector.MaxHealth);
            ChangeAttack(_attackInteractor.Attack);
        }

        private void OnOpen()
        {
            OnLoad();

            _healthInspector.ChangeHealthEvent += ChangeHealth;
            _attackInteractor.ChangeAttackEvent += ChangeAttack;
        }

        private void OnClose()
        {
            _healthInspector.ChangeHealthEvent -= ChangeHealth;
            _attackInteractor.ChangeAttackEvent -= ChangeAttack;
        }
        
        private void ChangeHealth(int health)
        {
            _view.ChangeHealth(health);
        }

        private void ChangeAttack(int attack)
        {
            _view.ChangeAttack(attack);
        }

        ~CharacteristicPresenter()
        {
            OnClose();
        }
    }
}