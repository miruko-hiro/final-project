using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Inventory.Backpack.Interactors;
using FinalProject.Architecture.Items.Scripts;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Sell
{
    public class SellWindowPresenter
    {
        private readonly SellWindow _view;
        private readonly BackpackWeaponsInteractor _weaponsInteractor;
        private readonly BackpackShieldsInteractor _shieldsInteractor;
        private readonly BackpackArmorsInteractor _armorsInteractor;
        private readonly AppearanceIssuanceSystem _dispenser;
        
        public SellWindowPresenter(SellWindow sellWindow, GameManager gameManager, AppearanceIssuanceSystem dispenser)
        {
            _view = sellWindow;
            _weaponsInteractor = gameManager.GetInteractor<BackpackWeaponsInteractor>();
            _shieldsInteractor = gameManager.GetInteractor<BackpackShieldsInteractor>();
            _armorsInteractor = gameManager.GetInteractor<BackpackArmorsInteractor>();
            _dispenser = dispenser;

            OnOpen();
        }

        private void OnLoad()
        {
            var weapons = _weaponsInteractor.GetItems();
            if (weapons != null && weapons.Count > 0)
                foreach (var weapon in weapons)
                    AddWeapon(weapon);
            
            var shields = _shieldsInteractor.GetItems();
            if (shields != null && shields.Count > 0)
                foreach (var shield in shields)
                    AddShield(shield);
            
            var armors = _armorsInteractor.GetItems();
            if (armors != null && armors.Count > 0)
                foreach (var armor in armors)
                    AddArmor(armor);
        }
        
        private void OnOpen()
        {
            //OnLoad();

            _view.OnEnabledEvent += OnLoad;
            
            // _weaponsInteractor.AddWeaponToBackpack += AddWeapon;
            // _shieldsInteractor.AddShieldToBackpack += AddShield;
            // _armorsInteractor.AddArmorToBackpack += AddArmor;
            
            _weaponsInteractor.RemoveWeaponToBackpack += RemoveItem;
            _shieldsInteractor.RemoveShieldToBackpack += RemoveItem;
            _armorsInteractor.RemoveArmorToBackpack += RemoveItem;
        }

        private void OnClose()
        {
            _view.OnEnabledEvent -= OnLoad;
            
            // _weaponsInteractor.AddWeaponToBackpack -= AddWeapon;
            // _shieldsInteractor.AddShieldToBackpack -= AddShield;
            // _armorsInteractor.AddArmorToBackpack -= AddArmor;
            
            _weaponsInteractor.RemoveWeaponToBackpack -= RemoveItem;
            _shieldsInteractor.RemoveShieldToBackpack -= RemoveItem;
            _armorsInteractor.RemoveArmorToBackpack -= RemoveItem;
        }
        
        private void AddWeapon(WeaponProperties weaponProperties)
        {
            _view.AddWeapon(weaponProperties);
        }
        
        private void AddShield(ShieldProperties shieldProperties)
        {
            _view.AddShield(shieldProperties);
        }
        
        private void AddArmor(ArmorProperties armorProperties)
        {
            _view.AddArmor(armorProperties);
        }
        
        private void RemoveItem(IItemProperties itemProperties)
        {
            _view.RemoveItem();
        }

        ~SellWindowPresenter()
        {
            OnClose();
        }
    }
}