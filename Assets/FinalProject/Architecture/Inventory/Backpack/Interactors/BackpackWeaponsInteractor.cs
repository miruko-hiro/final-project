using System;
using System.Collections.Generic;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Inventory.Backpack.Interactors
{
    public class BackpackWeaponsInteractor: Interactor
    {
        public event Action ChangeBackpackWeaponsEvent;
        public event Action<WeaponProperties> AddWeaponToBackpack;
        public event Action<WeaponProperties> RemoveWeaponToBackpack;
        
        private const string Key = "BACKPACK_WEAPONS_PROPERTIES";
        private StorageBase _storage;
        private SerializableList _items;

        public void AddWeapon(WeaponProperties weaponProperties)
        {
            _items.Add(weaponProperties);
            AddWeaponToBackpack?.Invoke(weaponProperties);
            SaveWeapons();
        }

        public List<WeaponProperties> GetItems()
        {
            return _items.GetList<WeaponProperties>(); 
        }

        public void RemoveWeapon(WeaponProperties weaponProperties)
        {
            _items.Remove(weaponProperties);
            RemoveWeaponToBackpack?.Invoke(weaponProperties);
            SaveWeapons();
        }

        private void SaveWeapons()
        {
            _storage.Set(Key, _items);
            ChangeBackpackWeaponsEvent?.Invoke();
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
            _items = storageBase.Get(Key, new SerializableList());
        }
    }
}