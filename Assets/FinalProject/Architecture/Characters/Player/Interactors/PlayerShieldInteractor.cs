using System;
using FinalProject.Architecture.Characters.Player.Repositories;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerShieldInteractor: Interactor
    {
        public event Action<ShieldProperties> ChangeShieldEvent;
        private PlayerShieldRepository _repository;

        public void ChangeShield(ShieldProperties shieldProperties)
        {
            _repository.ShieldProperties = shieldProperties;
            ChangeShieldEvent?.Invoke(shieldProperties);
        }

        public ShieldProperties GetShieldProperties()
        {
            return _repository.ShieldProperties;
        }

        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _repository = scene.GetRepository<PlayerShieldRepository>();
        }
    }
}