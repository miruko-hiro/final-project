using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Repositories
{
    public class PlayerHeadRepository: Repository
    {
        private const string Key = "PLAYER_HEAD_PROPERTIES";
        
        private StorageBase _storage;

        public HeadProperties HeadProperties
        {
            get => _storage.Get(Key, new HeadProperties(ArmorType.None, 0, 0));
            set => _storage.Set(Key, value);
        }

        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _storage = storageBase;
        }
    }
}