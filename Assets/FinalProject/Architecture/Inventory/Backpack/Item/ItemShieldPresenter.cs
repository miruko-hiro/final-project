using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Items.Scripts;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;

namespace FinalProject.Architecture.Inventory.Backpack.Item
{
    public class ItemShieldPresenter: IItemPresenter
    {
        private readonly ItemView _view;
        private readonly AppearanceIssuanceSystem _dispenser;
        private readonly InfoWindow _infoWindow;
        
        public ShieldProperties ShieldProperties { get; }
        public IItemProperties ItemProperties => ShieldProperties;

        public ItemShieldPresenter(ItemView view, ShieldProperties properties, AppearanceIssuanceSystem dispenser, InfoWindow infoWindow)
        {
            _view = view;
            ShieldProperties = properties;
            _dispenser = dispenser;
            _infoWindow = infoWindow;
            
            OnOpen();
        }

        private void LoadData()
        {
            SetShield(ShieldProperties);
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

        private void SetShield(ShieldProperties shieldProperties)
        {
            _view.Sprite = _dispenser.GetShield(shieldProperties);
        }
        
        private void AddInfoToInfoWindow()
        {
            _infoWindow.AddInfo(ShieldProperties, _view.gameObject);
        }

        ~ItemShieldPresenter()
        {
            OnClose();
        }
    }
}