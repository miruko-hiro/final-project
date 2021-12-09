using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.Backpack.Item;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.Backpack
{
    public class BackpackView : MonoBehaviour
    {
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private InfoWindow _infoWindow;
        private GameManager _gameManager;
        private AppearanceIssuanceSystem _dispenser;
        private ItemBackground[] _itemBackgroundArray;
        
        [Inject]
        private void Construct(GameManager gameManager, AppearanceIssuanceSystem dispenser)
        {
            _gameManager = gameManager;
            _dispenser = dispenser;
        }

        private void Awake()
        {
            _itemBackgroundArray = GetComponentsInChildren<ItemBackground>();
            
            var item = Instantiate(_itemPrefab, _itemBackgroundArray[0].transform).GetComponent<ItemView>();
            var armorProperties = new ArmorProperties(ItemType.Body, ArmorType.Light, 2, 1, 5, "item");
            item.Initialize(ItemType.Body, new ItemArmorPresenter(item, armorProperties, _dispenser, _infoWindow));
            
            item = Instantiate(_itemPrefab, _itemBackgroundArray[1].transform).GetComponent<ItemView>();
            var weaponProperties = new WeaponProperties(ItemType.Weapon, WeaponType.Sword, MagicType.None, 3, 1, 5, "item");
            item.Initialize(ItemType.Weapon, new ItemWeaponPresenter(item, weaponProperties, _dispenser, _infoWindow));
            
            item = Instantiate(_itemPrefab, _itemBackgroundArray[2].transform).GetComponent<ItemView>();
            var shieldProperties = new ShieldProperties(ItemType.Shield, ShieldType.Tower, 0, 5, 5, "item");
            item.Initialize(ItemType.Shield, new ItemShieldPresenter(item, shieldProperties, _dispenser, _infoWindow));
            
            item = Instantiate(_itemPrefab, _itemBackgroundArray[3].transform).GetComponent<ItemView>();
            armorProperties = new ArmorProperties(ItemType.Head, ArmorType.Light, 1, 1, 5, "item");
            item.Initialize(ItemType.Head, new ItemArmorPresenter(item, armorProperties, _dispenser, _infoWindow));
            
            item = Instantiate(_itemPrefab, _itemBackgroundArray[4].transform).GetComponent<ItemView>();
            armorProperties = new ArmorProperties(ItemType.Pants, ArmorType.None, 1, 1, 5, "item");
            item.Initialize(ItemType.Pants, new ItemArmorPresenter(item, armorProperties, _dispenser, _infoWindow));
            
            item = Instantiate(_itemPrefab, _itemBackgroundArray[5].transform).GetComponent<ItemView>();
            armorProperties = new ArmorProperties(ItemType.Boots, ArmorType.None, 1, 1, 5, "item");
            item.Initialize(ItemType.Boots, new ItemArmorPresenter(item, armorProperties, _dispenser, _infoWindow));
        }
    }
}