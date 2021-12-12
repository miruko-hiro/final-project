using FinalProject.Architecture.Game.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FinalProject.Architecture.Inventory.Money
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private Text _money;
        private MoneyPresenter _presenter;

        public string Text
        {
            get => _money.text;
            set => _money.text = value;
        }

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _presenter = new MoneyPresenter(this, gameManager);
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}