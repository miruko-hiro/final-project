using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.RightHand
{
    public class PlayerRightHandPresenter
    {
        private readonly PlayerRightHand _view;
        private readonly PlayerWeaponInteractor _interactor;
        private readonly AppearanceIssuanceSystem _dispenser;
        private readonly InfoWindow _infoWindow;

        public PlayerRightHandPresenter(PlayerRightHand view, GameManager gameManager, AppearanceIssuanceSystem dispenser, InfoWindow infoWindow)
        {
            _view = view;
            _dispenser = dispenser;
            _interactor = gameManager.GetInteractor<PlayerWeaponInteractor>();
            _infoWindow = infoWindow;
            
            OnOpen();
        }
        
        private void LoadData()
        {
            SetRightHand(_interactor.WeaponProperties);
        }

        private void OnOpen()
        {
            LoadData();
            
            _interactor.ChangeWeaponEvent += SetRightHand;
            _view.OnAddInfoToInfoWindowEvent += AddInfoToInfoWindow;
        }

        private void OnClose()
        {
            _interactor.ChangeWeaponEvent -= SetRightHand;
            _view.OnAddInfoToInfoWindowEvent -= AddInfoToInfoWindow;
        }

        private void SetRightHand(WeaponProperties weaponProperties)
        {
            _view.Sprite = _dispenser.GetWeapon(weaponProperties);
        }
        
        private void AddInfoToInfoWindow()
        {
            _infoWindow.AddInfo(_interactor.WeaponProperties);
        }


        ~PlayerRightHandPresenter()
        {
            OnClose();
        }
    }
}