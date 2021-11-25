using System;
using FinalProject.Architecture.Characters.Player.Repositories;
using FinalProject.Architecture.Characters.Scripts.Hair;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerHairInteractor: Interactor
    {
        public event Action<HairProperties> ChangeHairEvent;
        private PlayerHairRepository _repository;
        
        public void ChangeHair(HairProperties hairProperties)
        {
            _repository.HairProperties = hairProperties;
            ChangeHairEvent?.Invoke(hairProperties);
        }

        public HairProperties GetHairProperties()
        {
            return _repository.HairProperties;
        }
        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _repository = scene.GetRepository<PlayerHairRepository>();
        }
    }
}