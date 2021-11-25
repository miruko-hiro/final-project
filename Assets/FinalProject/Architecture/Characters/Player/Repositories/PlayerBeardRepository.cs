using FinalProject.Architecture.Characters.Scripts.Hair;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Repositories
{
    public class PlayerBeardRepository: Repository
    {
        private const string Key = "PLAYER_BEARD_PROPERTIES";
        
        private StorageBase _storage;

        public BeardProperties BeardProperties
        {
            get => _storage.Get(Key, new BeardProperties(HairColor.Black, BeardLength.None, 0));
            set => _storage.Set(Key, value);
        }
        
        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _storage = storageBase;
        }
    }
}