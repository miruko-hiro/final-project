using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.LeftHand
{
    public class PlayerLeftHandPresenter
    {
        private readonly PlayerLeftHand _view;
        private readonly PlayerShieldInteractor _interactor;
        private readonly AppearanceIssuanceSystem _dispenser;
        private readonly InfoWindow _infoWindow;

        public PlayerLeftHandPresenter(PlayerLeftHand view, GameManager gameManager, AppearanceIssuanceSystem dispenser, InfoWindow infoWindow)
        {
            _view = view;
            _dispenser = dispenser;
            _interactor = gameManager.GetInteractor<PlayerShieldInteractor>();
            _infoWindow = infoWindow;
            
            OnOpen();
        }
        
        private void LoadData()
        {
            SerLeftHand(_interactor.ShieldProperties);
        }

        private void OnOpen()
        {
            LoadData();
            
            _interactor.ChangeShieldEvent += SerLeftHand;
            _view.OnAddInfoToInfoWindowEvent += AddInfoToInfoWindow;
        }

        private void OnClose()
        {
            _interactor.ChangeShieldEvent -= SerLeftHand;
            _view.OnAddInfoToInfoWindowEvent -= AddInfoToInfoWindow;
        }

        private void SerLeftHand(ShieldProperties shieldProperties)
        {
            _view.Sprite = _dispenser.GetShield(shieldProperties);
        }
        
        private void AddInfoToInfoWindow()
        {
            _infoWindow.AddInfo(_interactor.ShieldProperties);
        }

        ~PlayerLeftHandPresenter()
        {
            OnClose();
        }
    }
}