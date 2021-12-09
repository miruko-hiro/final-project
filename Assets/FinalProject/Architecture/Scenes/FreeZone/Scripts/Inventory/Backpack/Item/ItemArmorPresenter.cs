using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.Backpack.Item
{
    public class ItemArmorPresenter: IItemPresenter
    {
        private readonly ItemView _view;
        private readonly AppearanceIssuanceSystem _dispenser;
        private readonly InfoWindow _infoWindow;
        public ArmorProperties ArmorProperties { get; }

        public ItemArmorPresenter(ItemView view, ArmorProperties armorProperties, AppearanceIssuanceSystem dispenser, InfoWindow infoWindow)
        {
            _view = view;
            ArmorProperties = armorProperties;
            _dispenser = dispenser;
            _infoWindow = infoWindow;
            
            OnOpen();
        }

        private void LoadData()
        {
            SetArmor(ArmorProperties);
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

        private void SetArmor(ArmorProperties armorProperties)
        {
            _view.Sprite = _dispenser.GetArmorSprite(armorProperties);
        }
        
        private void AddInfoToInfoWindow()
        {
            _infoWindow.AddInfo(ArmorProperties);
        }

        ~ItemArmorPresenter()
        {
            OnClose();
        }
    }
}