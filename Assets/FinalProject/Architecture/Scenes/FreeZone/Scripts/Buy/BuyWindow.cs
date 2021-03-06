using System;
using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Inventory.Backpack;
using FinalProject.Architecture.Inventory.Backpack.Item;
using FinalProject.Architecture.Items.Scripts;
using FinalProject.Architecture.Scenes.MainMenu.Scripts;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy
{
    public class BuyWindow : MonoBehaviour
    {
        [SerializeField] private InfoWindow _infoWindow;
        [SerializeField] private BackpackView _backpackView;
        private GameManager _gameManager;
        private AppearanceIssuanceSystem _dispenser;
        private SoundEffectsButtons _soundEffectsButtons;
        
        [Inject]
        private void Construct(GameManager gameManager, AppearanceIssuanceSystem dispenser, SoundEffectsButtons soundEffectsButtons)
        {
            _gameManager = gameManager;
            _dispenser = dispenser;
            _soundEffectsButtons = soundEffectsButtons;
        }
        
        private void Awake()
        {
            var items = GetComponentsInChildren<ItemView>();
            var level = _gameManager.GetInteractor<PlayerLevelInteractor>().Level;
            
            var valuesItemType = Enum.GetValues(typeof(ItemType));

            foreach (var item in items)
            {
                var itemTypeRandom = (ItemType)valuesItemType.GetValue(Random.Range(0, valuesItemType.Length - 1));

                if (itemTypeRandom == ItemType.Weapon) GeneratingWeapons(item, level);
                else if (itemTypeRandom == ItemType.Shield) GeneratingShields(item, level);
                else GeneratingArmors(itemTypeRandom, item, level);
            }
        }

        private void GeneratingWeapons(ItemView item, int level)
        {
            var valuesWeaponType = Enum.GetValues(typeof(WeaponType));
            var weaponTypeRandom = (WeaponType)valuesWeaponType.GetValue(Random.Range(1, valuesWeaponType.Length - 1));
            MagicType type = MagicType.None;

            if (weaponTypeRandom == WeaponType.Staff)
            {
                // var valuesMagicType = Enum.GetValues(typeof(MagicType));
                // type = (MagicType)valuesMagicType.GetValue(Random.Range(1, valuesMagicType.Length - 1));
                type = MagicType.Fire;
            }
            
            var spriteIndexRandom = _dispenser.GetRandomIndex(weaponTypeRandom, type);
            
            var attackScoreRandom = Random.Range(1, 3) * level;
            var priceRandom = Random.Range(5, 10) * level;
            var properties = new WeaponProperties(ItemType.Weapon, weaponTypeRandom, type, spriteIndexRandom, attackScoreRandom, priceRandom, "item");
            item.Initialize(ItemType.Weapon, new ItemWeaponPresenter(item, properties, _dispenser, _infoWindow));
        }

        private void GeneratingShields(ItemView item, int level)
        {
            var valuesShieldType = Enum.GetValues(typeof(ShieldType));
            var shieldTypeRandom = (ShieldType)valuesShieldType.GetValue(Random.Range(1, valuesShieldType.Length - 1));
            var spriteIndexRandom = _dispenser.GetRandomIndex(shieldTypeRandom);
            var protectionScoreRandom = Random.Range(1, 3) * level;
            var priceRandom = Random.Range(5, 10) * level;
            var properties = new ShieldProperties(ItemType.Shield, shieldTypeRandom, spriteIndexRandom, protectionScoreRandom, priceRandom, "item");
            item.Initialize(ItemType.Shield, new ItemShieldPresenter(item, properties, _dispenser, _infoWindow));
        }

        private void GeneratingArmors(ItemType itemType, ItemView item, int level)
        {
            ArmorType armorTypeRandom;
            if (itemType == ItemType.Pants || itemType == ItemType.Boots) armorTypeRandom = ArmorType.None;
            else
            {
                var valuesArmorType = Enum.GetValues(typeof(ArmorType));
                armorTypeRandom = (ArmorType)valuesArmorType.GetValue(Random.Range(1, valuesArmorType.Length - 1));
            }
            
            var spriteIndexRandom = _dispenser.GetRandomIndex(itemType, armorTypeRandom);
            var protectionScoreRandom = Random.Range(1, 3) * level;
            var priceRandom = Random.Range(5, 10) * level;
            var properties = new ArmorProperties(itemType, armorTypeRandom, spriteIndexRandom, protectionScoreRandom, priceRandom, "item");
            item.Initialize(itemType, new ItemArmorPresenter(item, properties, _dispenser, _infoWindow));
        }

        public void OnClick()
        {
            _soundEffectsButtons.SoundEffectClick();
            _infoWindow.gameObject.SetActive(true);
        }

        public void OnClickExit()
        {
            _soundEffectsButtons.SoundEffectBack();
            gameObject.SetActive(false);
        }

        public bool OnClickBuy(IItemProperties itemProperties)
        {
            _soundEffectsButtons.SoundEffectClick();
            return _backpackView.Presenter.Buy(itemProperties);
        }
    }
}
