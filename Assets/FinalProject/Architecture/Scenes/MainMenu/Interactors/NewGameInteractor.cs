using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.MainMenu.Interactors
{
    public class NewGameInteractor: Interactor
    {
        private const string Key = "NEW_GAME_PROPERTIES";
        private StorageBase _storage;
        
        public bool NewGame
        {
            get => _storage.Get(Key, false);
            set
            {
                _storage.Set(Key, value);
            }
        }

        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}