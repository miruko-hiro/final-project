using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Repositories
{
    public class PlayerWeaponRepository: Repository
    {
        private const string Key = "PLAYER_WEAPON_PROPERTIES";
        
        private StorageBase _storage;
        
        public WeaponProperties WeaponProperties
        {
            get => _storage.Get(Key, new WeaponProperties(WeaponType.Sword, MagicType.None, 0, 1));
            set => _storage.Set(Key, value);
        }
        
        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _storage = storageBase;
        }
    }
}