using System;
using FinalProject.Architecture.Characters.Player.Repositories;
using FinalProject.Architecture.Characters.Scripts.Hair;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerBeardInteractor: Interactor
    {
        public event Action<BeardProperties> ChangeBeardEvent;
        private PlayerBeardRepository _repository;
        
        public void ChangeBeard(BeardProperties beardProperties)
        {
            _repository.BeardProperties = beardProperties;
            ChangeBeardEvent?.Invoke(beardProperties);
        }

        public BeardProperties GetBeardProperties()
        {
            return _repository.BeardProperties;
        }
        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _repository = scene.GetRepository<PlayerBeardRepository>();
        }
    }
}