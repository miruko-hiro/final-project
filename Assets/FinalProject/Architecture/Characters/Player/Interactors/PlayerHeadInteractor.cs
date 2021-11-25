using System;
using FinalProject.Architecture.Characters.Player.Repositories;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerHeadInteractor: Interactor
    {
        public event Action<HeadProperties> ChangeHeadEvent;
        private PlayerHeadRepository _repository;

        public void ChangeHead(HeadProperties headProperties)
        {
            _repository.HeadProperties = headProperties;
            ChangeHeadEvent?.Invoke(headProperties);
        }

        public HeadProperties GetHeadProperties()
        {
            return _repository.HeadProperties;
        }
        
        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _repository = scene.GetRepository<PlayerHeadRepository>();
        }
    }
}