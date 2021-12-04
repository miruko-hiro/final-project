using System;
using FinalProject.Architecture.Characters.Scripts.Hair;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerBeardInteractor: Interactor
    {
        public event Action<BeardProperties> ChangeBeardEvent;
        
        private const string Key = "PLAYER_BEARD_PROPERTIES";
        private StorageBase _storage;
        
        public BeardProperties BeardProperties
        {
            get => _storage.Get(Key, new BeardProperties(HairColor.Black, BeardLength.None, 0));
            set
            {
                ChangeBeardEvent?.Invoke(value);
                _storage.Set(Key, value);
            } 
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}