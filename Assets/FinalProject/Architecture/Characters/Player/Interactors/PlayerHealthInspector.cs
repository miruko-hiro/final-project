using System;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerHealthInspector: Interactor
    {
        public event Action<int> ChangeHealthEvent;
        public event Action<int> IncreaseHealthEvent;
        public event Action<int> ReduceHealthEvent;
        
        private const string Key = "PLAYER_HEALTH_PROPERTIES";
        private StorageBase _storage;
        private int _health;
        
        public int Health
        {
            get => _health;
            set
            {
                if(_health == value || value < 0) return; 
                if (_health > value) ReduceHealthEvent?.Invoke(value);
                else IncreaseHealthEvent?.Invoke(value);
                _health = value;
            }
        }
        
        public int MaxHealth
        {
            get => _storage.Get(Key, 5);
            set
            {
                var val = _storage.Get<int>(Key); 
                if(val == value || value < 0) return; 
                ChangeHealthEvent?.Invoke(value); 
                _storage.Set(Key, value);
            }
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}