using System;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerMoneyInteractor: Interactor
    {
        public event Action<int> ChangeMoneyEvent;
        
        private const string Key = "PLAYER_MONEY_PROPERTIES";
        private StorageBase _storage;
        
        public int Money
        {
            get => _storage.Get(Key, 10);
            set
            {
                if(value < 0) return;
                ChangeMoneyEvent?.Invoke(value);
                _storage.Set(Key, value);
            } 
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}