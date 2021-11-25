using System;
using FinalProject.Architecture.Characters.Player.Repositories;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerBootsInteractor: Interactor
    {
        public event Action<BootsProperties> ChangeBootsEvent;
        private PlayerBootsRepository _repository;

        public void ChangeBoots(BootsProperties bootsProperties)
        {
            _repository.BootsProperties = bootsProperties;
            ChangeBootsEvent?.Invoke(bootsProperties);
        }

        public BootsProperties GetBootsProperties()
        {
            return _repository.BootsProperties;
        }
        
        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _repository = scene.GetRepository<PlayerBootsRepository>();
        }
    }
}