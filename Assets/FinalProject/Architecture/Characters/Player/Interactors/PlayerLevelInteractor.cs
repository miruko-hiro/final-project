using System;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerLevelInteractor: Interactor
    {
        public event Action<int> ChangeLevelEvent;
        
        private const string Key = "PLAYER_LEVEL_PROPERTIES";
        private StorageBase _storage;
        
        public int Level
        {
            get => _storage.Get(Key, 1);
            set
            {
                ChangeLevelEvent?.Invoke(value);
                _storage.Set(Key, value);
            } 
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}