using System;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Inventory.Backpack.Interactors
{
    public class BackpackSpaceOccupiedInteractor: Interactor
    {
        public event Action<int> ChangeSpaceOccupiedEvent;
        
        private const string Key = "BACKPACK_SPACE_OCCUPIED_PROPERTIES";
        private StorageBase _storage;
        
        public int SpaceOccupied
        {
            get => _storage.Get(Key, 0);
            set
            {
                ChangeSpaceOccupiedEvent?.Invoke(value);
                _storage.Set(Key, value);
            } 
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}