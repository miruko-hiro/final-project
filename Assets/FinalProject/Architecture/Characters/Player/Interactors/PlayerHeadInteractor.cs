using System;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Storage.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerHeadInteractor: PlayerArmorInteractor
    {
        public override event Action<ArmorProperties> ChangeArmorEvent;
        
        private const string Key = "PLAYER_HEAD_PROPERTIES";
        private StorageBase _storage;

        public override ArmorProperties ArmorProperties
        {
            get => _storage.Get(Key, new ArmorProperties(ItemType.Head, ArmorType.None, 0, 0, 5, "item"));
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