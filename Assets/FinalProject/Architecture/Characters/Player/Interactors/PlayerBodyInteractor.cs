using System;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerBodyInteractor: PlayerArmorInteractor
    {
        public override event Action<ArmorProperties> ChangeArmorEvent;
        
        private const string Key = "PLAYER_BODY_PROPERTIES";
        private StorageBase _storage;

        public override ArmorProperties ArmorProperties
        {
            get => _storage.Get(Key, new ArmorProperties(ItemType.Body, ArmorType.Light, 0, 0, 5, "item"));
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