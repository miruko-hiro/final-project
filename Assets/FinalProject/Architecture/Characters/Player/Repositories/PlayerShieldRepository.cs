using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Repositories
{
    public class PlayerShieldRepository: Repository
    {
        private const string Key = "PLAYER_SHIELD_PROPERTIES";
        
        private StorageBase _storage;
        
        public ShieldProperties ShieldProperties
        {
            get => _storage.Get(Key, new ShieldProperties(ShieldType.None, 0, 0));
            set => _storage.Set(Key, value);
        }
        
        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _storage = storageBase;
        }
        
    }
}