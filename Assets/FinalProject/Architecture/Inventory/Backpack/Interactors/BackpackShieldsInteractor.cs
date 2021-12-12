using System;
using System.Collections.Generic;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Inventory.Backpack.Interactors
{
    public class BackpackShieldsInteractor: Interactor
    {
        public event Action ChangeBackpackShieldsEvent;
        public event Action<ShieldProperties> AddShieldToBackpack;
        public event Action<ShieldProperties> RemoveShieldToBackpack;
        
        private const string Key = "BACKPACK_SHIELDS_PROPERTIES";
        private StorageBase _storage;
        private SerializableList _items;

        public void AddShield(ShieldProperties shieldProperties)
        {
            _items.Add(shieldProperties);
            AddShieldToBackpack?.Invoke(shieldProperties);
            SaveWeapons();
        }

        public List<ShieldProperties> GetItems()
        {
            return _items.GetList<ShieldProperties>(); 
        }

        public void RemoveShield(ShieldProperties shieldProperties)
        {
            _items.Remove(shieldProperties);
            RemoveShieldToBackpack?.Invoke(shieldProperties);
            SaveWeapons();
        }

        private void SaveWeapons()
        {
            _storage.Set(Key, _items);
            ChangeBackpackShieldsEvent?.Invoke();
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
            _items = storageBase.Get(Key, new SerializableList());
        }
    }
}