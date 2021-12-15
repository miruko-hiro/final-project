using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Inventory.Backpack.Interactors;
using FinalProject.Architecture.Items.Scripts;

namespace FinalProject.Architecture.Inventory.Backpack
{
    public class BackpackPresenter
    {
        private readonly BackpackView _view;
        private readonly PlayerMoneyInteractor _moneyInteractor;
        private readonly BackpackWeaponsInteractor _weaponsInteractor;
        private readonly BackpackShieldsInteractor _shieldsInteractor;
        private readonly BackpackArmorsInteractor _armorsInteractor;
        private readonly BackpackSpaceOccupiedInteractor _spaceOccupiedInteractor;

        public BackpackPresenter(BackpackView infoWindow, GameManager gameManager)
        {
            _view = infoWindow;
            _moneyInteractor = gameManager.GetInteractor<PlayerMoneyInteractor>();
            _weaponsInteractor = gameManager.GetInteractor<BackpackWeaponsInteractor>();
            _shieldsInteractor = gameManager.GetInteractor<BackpackShieldsInteractor>();
            _armorsInteractor = gameManager.GetInteractor<BackpackArmorsInteractor>();
            _spaceOccupiedInteractor = gameManager.GetInteractor<BackpackSpaceOccupiedInteractor>();

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
            OnLoad();
            
            _weaponsInteractor.AddWeaponToBackpack += AddWeapon;
            _shieldsInteractor.AddShieldToBackpack += AddShield;
            _armorsInteractor.AddArmorToBackpack += AddArmor;
            
            _weaponsInteractor.RemoveWeaponToBackpack += RemoveItem;
            _shieldsInteractor.RemoveShieldToBackpack += RemoveItem;
            _armorsInteractor.RemoveArmorToBackpack += RemoveItem;
        }

        private void OnClose()
        {
            _weaponsInteractor.AddWeaponToBackpack -= AddWeapon;
            _shieldsInteractor.AddShieldToBackpack -= AddShield;
            _armorsInteractor.AddArmorToBackpack -= AddArmor;
            
            _weaponsInteractor.RemoveWeaponToBackpack -= RemoveItem;
            _shieldsInteractor.RemoveShieldToBackpack -= RemoveItem;
            _armorsInteractor.RemoveArmorToBackpack -= RemoveItem;
        }

        public bool Sell(IItemProperties itemProperties)
        {
            if (itemProperties.ItemType == ItemType.Weapon) RemoveWeaponToBackpack(itemProperties);
            else if (itemProperties.ItemType == ItemType.Shield) RemoveShieldToBackpack(itemProperties);
            else RemoveArmorToBackpack(itemProperties);
            _moneyInteractor.Money += itemProperties.Price;
            _spaceOccupiedInteractor.SpaceOccupied -= 1;
            return true;
        }

        public void Remove(IItemProperties itemProperties)
        {
            if (itemProperties.ItemType == ItemType.Weapon) RemoveWeaponToBackpack(itemProperties);
            else if (itemProperties.ItemType == ItemType.Shield) RemoveShieldToBackpack(itemProperties);
            else RemoveArmorToBackpack(itemProperties);
            _spaceOccupiedInteractor.SpaceOccupied -= 1;
        }

        private void RemoveWeaponToBackpack(IItemProperties itemProperties)
        {
            _weaponsInteractor.RemoveWeapon(itemProperties as WeaponProperties);
        }

        private void RemoveShieldToBackpack(IItemProperties itemProperties)
        {
            _shieldsInteractor.RemoveShield(itemProperties as ShieldProperties);
        }

        private void RemoveArmorToBackpack(IItemProperties itemProperties)
        {
            _armorsInteractor.RemoveArmor(itemProperties as ArmorProperties);
        }
        
        private void RemoveItem(IItemProperties itemProperties)
        {
            _view.RemoveItem(itemProperties);
        }

        public bool Buy(IItemProperties itemProperties)
        {
            if (_moneyInteractor.Money < itemProperties.Price && _spaceOccupiedInteractor.SpaceOccupied >= 30)
                return false;
            if (itemProperties.ItemType == ItemType.Weapon) AddWeaponToBackpack(itemProperties);
            else if (itemProperties.ItemType == ItemType.Shield) AddShieldToBackpack(itemProperties);
            else AddArmorToBackpack(itemProperties);
            _moneyInteractor.Money -= itemProperties.Price;
            _spaceOccupiedInteractor.SpaceOccupied += 1;

            return true;
        }

        public void Add(IItemProperties itemProperties)
        {
            if (_spaceOccupiedInteractor.SpaceOccupied >= 30)
                return;
            if (itemProperties.ItemType == ItemType.Weapon) AddWeaponToBackpack(itemProperties);
            else if (itemProperties.ItemType == ItemType.Shield) AddShieldToBackpack(itemProperties);
            else AddArmorToBackpack(itemProperties);
            _spaceOccupiedInteractor.SpaceOccupied += 1;
        }

        private void AddWeaponToBackpack(IItemProperties itemProperties)
        {
            _weaponsInteractor.AddWeapon(itemProperties as WeaponProperties);
        }

        private void AddShieldToBackpack(IItemProperties itemProperties)
        {
            _shieldsInteractor.AddShield(itemProperties as ShieldProperties);
        }

        private void AddArmorToBackpack(IItemProperties itemProperties)
        {
            _armorsInteractor.AddArmor(itemProperties as ArmorProperties);
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

        ~BackpackPresenter()
        {
            OnClose();
        }
    }
}
