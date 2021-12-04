using System;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerBootsInteractor: Interactor
    {
        public event Action<BootsProperties> ChangeBootsEvent;
        
        private const string Key = "PLAYER_BOOTS_PROPERTIES";
        private StorageBase _storage;

        public BootsProperties BootsProperties
        {
            get => _storage.Get(Key, new BootsProperties(-1, 0));
            set
            {
                ChangeBootsEvent?.Invoke(value);
                _storage.Set(Key, value);
            } 
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}