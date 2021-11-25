using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Repositories
{
    public class PlayerHealthRepository: Repository
    {
        private const string Key = "PLAYER_HEALTH_PROPERTIES";
        
        private StorageBase _storage;

        public int Health
        {
            get => _storage.Get(Key, 5);
            set => _storage.Set(Key, value);
        }

        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _storage = storageBase;
        }
    }
}