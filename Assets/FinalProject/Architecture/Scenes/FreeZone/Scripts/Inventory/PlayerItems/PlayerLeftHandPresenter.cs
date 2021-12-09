using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.PlayerItems
{
    public class PlayerLeftHandPresenter
    {
        private readonly PlayerLeftHand _view;
        private readonly PlayerShieldInteractor _interactor;
        public ShieldProperties ShieldProperties => _interactor.ShieldProperties;

        public PlayerLeftHandPresenter(PlayerLeftHand view, GameManager gameManager)
        {
            _view = view;
            _interactor = gameManager.GetInteractor<PlayerShieldInteractor>();
            
            OnOpen();
        }
        
        private void LoadData()
        {
            SetLeftHand(_interactor.ShieldProperties);
        }

        private void OnOpen()
        {
            LoadData();
            
            _view.OnAddItemToLeftHandEvent += SetLeftHand;
        }

        private void OnClose()
        {
            _view.OnAddItemToLeftHandEvent -= SetLeftHand;
        }

        private void SetLeftHand(ShieldProperties shieldProperties)
        {
            
            if (shieldProperties == null)
                _interactor.ShieldProperties = new ShieldProperties(ItemType.Shield, ShieldType.None, -1, 0, 0, "");
            else
                _interactor.ShieldProperties = shieldProperties;
        }

        ~PlayerLeftHandPresenter()
        {
            OnClose();
        }
    }
}