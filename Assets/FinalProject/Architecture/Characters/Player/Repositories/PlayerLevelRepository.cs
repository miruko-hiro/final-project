using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Repositories
{
    public class PlayerLevelRepository: Repository
    {
        private const string Key = "PLAYER_LEVEL_PROPERTIES";
        
        private StorageBase _storage;

        public int Level
        {
            get => _storage.Get(Key, 0);
            set => _storage.Set(Key, value);
        }

        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _storage = storageBase;
        }
    }
}