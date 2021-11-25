using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Repositories
{
    public class PlayerBodyRepository: Repository
    {
        private const string Key = "PLAYER_BODY_PROPERTIES";
        
        private StorageBase _storage;

        public BodyProperties BodyProperties
        {
            get => _storage.Get(Key, new BodyProperties(ArmorType.Light, 0, 0));
            set => _storage.Set(Key, value);
        }

        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _storage = storageBase;
        }
    }
}