using System;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerWeaponInteractor: Interactor
    {
        public event Action<WeaponProperties> ChangeWeaponEvent; 
        
        private const string Key = "PLAYER_WEAPON_PROPERTIES";
        private StorageBase _storage;
        
        public WeaponProperties WeaponProperties
        {
            get => _storage.Get(Key, new WeaponProperties(WeaponType.Sword, MagicType.None, 0, 1));
            set
            {
                ChangeWeaponEvent?.Invoke(value);
                _storage.Set(Key, value);
            } 
        }

        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}