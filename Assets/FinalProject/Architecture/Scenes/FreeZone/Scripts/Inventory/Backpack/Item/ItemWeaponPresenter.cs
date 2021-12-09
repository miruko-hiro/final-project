using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.Backpack.Item
{
    public class ItemWeaponPresenter: IItemPresenter
    {
        private readonly ItemView _view;
        private readonly AppearanceIssuanceSystem _dispenser;
        private readonly InfoWindow _infoWindow;
        public WeaponProperties WeaponProperties { get; }

        public ItemWeaponPresenter(ItemView view, WeaponProperties properties, AppearanceIssuanceSystem dispenser, InfoWindow infoWindow)
        {
            _view = view;
            _dispenser = dispenser;
            _infoWindow = infoWindow;
            WeaponProperties = properties;
            
            OnOpen();
        }

        private void LoadData()
        {
            SetWeapon();
        }

        private void OnOpen()
        {
            LoadData();
            
            _view.OnAddInfoToInfoWindowEvent += AddInfoToInfoWindow;
        }
        
        private void OnClose()
        {
            _view.OnAddInfoToInfoWindowEvent -= AddInfoToInfoWindow;
        }

        private void SetWeapon()
        {
            _view.Sprite = _dispenser.GetWeapon(WeaponProperties);
        }
        
        private void AddInfoToInfoWindow()
        {
            _infoWindow.AddInfo(WeaponProperties);
        }

        ~ItemWeaponPresenter()
        {
            OnClose();
        }
    }
}