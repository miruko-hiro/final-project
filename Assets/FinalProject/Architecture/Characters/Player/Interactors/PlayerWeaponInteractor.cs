using System;
using FinalProject.Architecture.Characters.Player.Repositories;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerWeaponInteractor: Interactor
    {
        public event Action<WeaponProperties> ChangeWeaponEvent;
        private PlayerWeaponRepository _repository;

        public void ChangeWeapon(WeaponProperties weaponProperties)
        {
            _repository.WeaponProperties = weaponProperties;
            ChangeWeaponEvent?.Invoke(weaponProperties);
        }

        public WeaponProperties GetWeaponProperties()
        {
            return _repository.WeaponProperties;
        }

        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _repository = scene.GetRepository<PlayerWeaponRepository>();
        }
    }
}