using System;
using FinalProject.Architecture.Characters.Player.Repositories;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerBodyInteractor: Interactor
    {
        public event Action<BodyProperties> ChangeBodyEvent;
        private PlayerBodyRepository _repository;

        public void ChangeBody(BodyProperties bodyProperties)
        {
            _repository.BodyProperties = bodyProperties;
            ChangeBodyEvent?.Invoke(bodyProperties);
        }

        public BodyProperties GetBodyProperties()
        {
            return _repository.BodyProperties;
        }
        
        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _repository = scene.GetRepository<PlayerBodyRepository>();
        }
    }
}