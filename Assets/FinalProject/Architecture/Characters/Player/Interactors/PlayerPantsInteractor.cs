using System;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerPantsInteractor: PlayerArmorInteractor
    {
        public override event Action<ArmorProperties> ChangeArmorEvent;
        
        private const string Key = "PLAYER_PANTS_PROPERTIES";
        private StorageBase _storage;

        public override ArmorProperties ArmorProperties
        {
            get => _storage.Get(Key, new ArmorProperties(ItemType.Pants, ArmorType.None, -1, 0, 5, "item"));
            set
            {
                ChangeArmorEvent?.Invoke(value);
                _storage.Set(Key, value);
            } 
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}