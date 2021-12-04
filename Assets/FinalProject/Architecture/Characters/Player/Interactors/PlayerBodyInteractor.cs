using System;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerBodyInteractor: Interactor
    {
        public event Action<BodyProperties> ChangeBodyEvent;
        
        private const string Key = "PLAYER_BODY_PROPERTIES";
        private StorageBase _storage;

        public BodyProperties BodyProperties
        {
            get => _storage.Get(Key, new BodyProperties(ArmorType.Light, 0, 0));
            set
            {
                ChangeBodyEvent?.Invoke(value);
                _storage.Set(Key, value);
            } 
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}