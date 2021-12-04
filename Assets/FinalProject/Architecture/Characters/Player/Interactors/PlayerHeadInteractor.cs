using System;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerHeadInteractor: Interactor
    {
        public event Action<HeadProperties> ChangeHeadEvent;
        
        private const string Key = "PLAYER_HEAD_PROPERTIES";
        private StorageBase _storage;

        public HeadProperties HeadProperties
        {
            get => _storage.Get(Key, new HeadProperties(ArmorType.None, 0, 0));
            set
            {
                ChangeHeadEvent?.Invoke(value);
                _storage.Set(Key, value);
            }
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}