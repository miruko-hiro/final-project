using System;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerAttackInteractor: Interactor
    {
        public event Action<int> ChangeAttackEvent;
        
        private const string Key = "PLAYER_ATTACK_PROPERTIES";
        private StorageBase _storage;
        
        public int Attack
        {
            get => _storage.Get(Key, 1);
            set
            {
                ChangeAttackEvent?.Invoke(value); 
                _storage.Set(Key, value);
            }
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}