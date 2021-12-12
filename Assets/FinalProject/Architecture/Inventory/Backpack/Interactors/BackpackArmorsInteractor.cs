using System;
using System.Collections.Generic;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Inventory.Backpack.Interactors
{
    public class BackpackArmorsInteractor: Interactor
    {
        public event Action ChangeBackpackArmorsEvent;
        public event Action<ArmorProperties> AddArmorToBackpack;
        public event Action<ArmorProperties> RemoveArmorToBackpack;
        
        private const string Key = "BACKPACK_ARMORS_PROPERTIES";
        private StorageBase _storage;
        private SerializableList _items;

        public void AddArmor(ArmorProperties armorProperties)
        {
            _items.Add(armorProperties);
            AddArmorToBackpack?.Invoke(armorProperties);
            SaveWeapons();
        }

        public List<ArmorProperties> GetItems()
        {
            return _items.GetList<ArmorProperties>(); 
        }

        public void RemoveArmor(ArmorProperties armorProperties)
        {
            _items.Remove(armorProperties);
            RemoveArmorToBackpack?.Invoke(armorProperties);
            SaveWeapons();
        }

        private void SaveWeapons()
        {
            _storage.Set(Key, _items);
            ChangeBackpackArmorsEvent?.Invoke();
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
            _items = storageBase.Get(Key, new SerializableList());
        }
    }
}