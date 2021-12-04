using System;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerPantsInteractor: Interactor
    {
        public event Action<PantsProperties> ChangePantsEvent;
        
        private const string Key = "PLAYER_PANTS_PROPERTIES";
        private StorageBase _storage;

        public PantsProperties PantsProperties
        {
            get => _storage.Get(Key, new PantsProperties(-1, 0));
            set
            {
                ChangePantsEvent?.Invoke(value);
                _storage.Set(Key, value);
            } 
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}