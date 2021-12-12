using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Game.Scripts;

namespace FinalProject.Architecture.Inventory.Money
{
    public class MoneyPresenter
    {
        private readonly MoneyView _view;
        private readonly PlayerMoneyInteractor _interactor;

        public MoneyPresenter(MoneyView view, GameManager gameManager)
        {
            _view = view;
            _interactor = gameManager.GetInteractor<PlayerMoneyInteractor>();

            OnOpen();
        }

        private void OnOpen()
        {
            OnLoad();
            
            _interactor.ChangeMoneyEvent += SetMoney;
        }
        private void OnLoad()
        {
            SetMoney(_interactor.Money);
        }

        private void SetMoney(int money)
        {
            _view.Text = money.ToString();
        }

        private void OnClose()
        {
            _interactor.ChangeMoneyEvent -= SetMoney;
        }

        ~MoneyPresenter()
        {
            OnClose();
        }
    }
}