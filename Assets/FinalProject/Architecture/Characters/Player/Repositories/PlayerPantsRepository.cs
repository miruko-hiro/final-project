using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Repositories
{
    public class PlayerPantsRepository: Repository
    {
        private const string Key = "PLAYER_PANTS_PROPERTIES";
        
        private StorageBase _storage;

        public PantsProperties PantsProperties
        {
            get => _storage.Get(Key, new PantsProperties(-1, 0));
            set => _storage.Set(Key, value);
        }

        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _storage = storageBase;
        }
    }
}