using System;
using FinalProject.Architecture.Characters.Scripts.Hair;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerHairInteractor: Interactor
    {
        public event Action<HairProperties> ChangeHairEvent;
        
        private const string Key = "PLAYER_HAIR_PROPERTIES";
        private StorageBase _storage;
        
        public HairProperties HairProperties
        {
            get => _storage.Get(Key, new HairProperties(HairColor.Black, HairLength.None, 0));
            set
            {
                ChangeHairEvent?.Invoke(value);
                _storage.Set(Key, value);
            } 
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}