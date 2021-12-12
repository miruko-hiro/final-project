using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Inventory.Backpack;
using FinalProject.Architecture.Inventory.Backpack.Item;
using FinalProject.Architecture.Items.Scripts;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Sell
{
    public class SellWindow: MonoBehaviour
    {
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private InfoWindow _infoWindow;
        [SerializeField] private BackpackView _backpackView;
        private SellWindowPresenter _presenter;
        private AppearanceIssuanceSystem _dispenser;
        private ItemBackground[] _itemBackgroundArray;
        
        [Inject]
        private void Construct(GameManager gameManager, AppearanceIssuanceSystem dispenser)
        {
            _dispenser = dispenser;
            _itemBackgroundArray = GetComponentsInChildren<ItemBackground>();
            _presenter = new SellWindowPresenter(this, gameManager, dispenser);
        }

        public void AddWeapon(WeaponProperties weaponProperties)
        {
            var item = GetFreeItemView();
            if(item == null) return;
            item.Initialize(ItemType.Weapon, new ItemWeaponPresenter(item, weaponProperties, _dispenser, _infoWindow));
        }

        public void AddShield(ShieldProperties shieldProperties)
        {
            var item = GetFreeItemView();
            if(item == null) return;
            item.Initialize(ItemType.Shield, new ItemShieldPresenter(item, shieldProperties, _dispenser, _infoWindow));
        }

        public void AddArmor(ArmorProperties armorProperties)
        {
            var item = GetFreeItemView();
            if(item == null) return;
            item.Initialize(armorProperties.ItemType, new ItemArmorPresenter(item, armorProperties, _dispenser, _infoWindow));
        }

        public void RemoveItem()
        {
            Destroy(_infoWindow.ItemObject);
        }

        private ItemView GetFreeItemView()
        {
            foreach (var itemBackground in _itemBackgroundArray)
            {
                var item = itemBackground.GetComponentInChildren<ItemView>();
                if (item == null)
                {
                    var itemObj = Instantiate(_itemPrefab, itemBackground.transform);
                    itemObj.GetComponent<Button>().onClick.AddListener(OnClick);
                    return itemObj.GetComponent<ItemView>();
                }
            }

            return null;
        }
        
        public void OnClick()
        {
            _infoWindow.gameObject.SetActive(true);
        }

        public void OnClickExit()
        {
            gameObject.SetActive(false);
        }

        public bool OnClickSell(IItemProperties itemProperties)
        {
            return _backpackView.Presenter.Remove(itemProperties);
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}