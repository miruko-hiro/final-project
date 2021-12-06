using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.ItemArmor
{
    public class PlayerArmorPresenter
    {
        private readonly PlayerArmor _view;
        private AppearanceIssuanceSystem _dispenser;
        private PlayerArmorInteractor _interactor;
        private readonly InfoWindow _infoWindow;

        public PlayerArmorPresenter(PlayerArmor view, PlayerArmorInteractor interactor, AppearanceIssuanceSystem dispenser, InfoWindow infoWindow)
        {
            _view = view;
            _dispenser = dispenser;
            _interactor = interactor;
            _infoWindow = infoWindow;
            
            OnOpen();
        }
        
        private void LoadData()
        {
            SetArmor(_interactor.ArmorProperties);
        }

        private void OnOpen()
        {
            LoadData();
            
            _interactor.ChangeArmorEvent += SetArmor;
            _view.OnAddInfoToInfoWindowEvent += AddInfoToInfoWindow;
        }

        private void OnClose()
        {
            _interactor.ChangeArmorEvent -= SetArmor;
            _view.OnAddInfoToInfoWindowEvent -= AddInfoToInfoWindow;
        }

        private void SetArmor(ArmorProperties armorProperties)
        {
            _view.Sprite = _dispenser.GetArmorSprite(armorProperties);
        }
        
        private void AddInfoToInfoWindow()
        {
            _infoWindow.AddInfo(_interactor.ArmorProperties);
        }

        ~PlayerArmorPresenter()
        {
            OnClose();
        }
    }
}