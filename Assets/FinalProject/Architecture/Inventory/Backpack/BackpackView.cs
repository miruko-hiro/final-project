using System;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Inventory.Backpack.Item;
using FinalProject.Architecture.Items.Scripts;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Inventory.Backpack
{
    public class BackpackView : MonoBehaviour
    {
        [SerializeField] private GameObject _backpack;
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private InfoWindow _infoWindow;
        private AppearanceIssuanceSystem _dispenser;
        private ItemBackground[] _itemBackgroundArray;
        private GameManager _gameManager;
        public BackpackPresenter Presenter { get; private set; }

        [Inject]
        private void Construct(GameManager gameManager, AppearanceIssuanceSystem dispenser)
        {
            _dispenser = dispenser;
            _itemBackgroundArray = _backpack.GetComponentsInChildren<ItemBackground>();
            _gameManager = gameManager;
        }

        private void Awake()
        {
            Presenter = new BackpackPresenter(this, _gameManager);
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

        private ItemView GetFreeItemView()
        {
            foreach (var itemBackground in _itemBackgroundArray)
            {
                var item = itemBackground.GetComponentInChildren<ItemView>();
                if (item == null)
                {
                    return Instantiate(_itemPrefab, itemBackground.transform).GetComponent<ItemView>();
                }
            }

            return null;
        }

        public void RemoveItem(IItemProperties itemProperties)
        {
            foreach (var itemBackground in _itemBackgroundArray)
            {
                var item = itemBackground.GetComponentInChildren<ItemView>();
                if (item != null && item.Presenter.ItemProperties == itemProperties)
                {
                    Destroy(item.gameObject);
                    break;
                }
            }
        }
    }
}