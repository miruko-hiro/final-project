using System;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerShieldInteractor: Interactor
    {
        public event Action<ShieldProperties> ChangeShieldEvent; 
        
        private const string Key = "PLAYER_SHIELD_PROPERTIES";
        private StorageBase _storage;
        
        public ShieldProperties ShieldProperties
        {
            get => _storage.Get(Key, new ShieldProperties(ItemType.Shield, ShieldType.None, 0, 0, 5, "item"));
            set
            {
                ChangeShieldEvent?.Invoke(value);
                _storage.Set(Key, value);
            } 
        }

        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}