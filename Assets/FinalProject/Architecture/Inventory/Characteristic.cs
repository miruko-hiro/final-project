using FinalProject.Architecture.Game.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FinalProject.Architecture.Inventory
{
    public class Characteristic : MonoBehaviour
    {
        [SerializeField] private Text _health;
        [SerializeField] private Text _attack;
        private CharacteristicPresenter _presenter;
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        private void Start()
        {
            _presenter = new CharacteristicPresenter(this, _gameManager);
        }

        public void ChangeHealth(int health)
        {
            _health.text = "Health: " + health;
        }

        public void ChangeAttack(int attack)
        {
            _attack.text = "Attack: " + attack;
        }
    }
}
