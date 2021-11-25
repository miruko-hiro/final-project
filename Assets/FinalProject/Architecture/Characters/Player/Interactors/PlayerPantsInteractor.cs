using System;
using FinalProject.Architecture.Characters.Player.Repositories;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerPantsInteractor: Interactor
    {
        public event Action<PantsProperties> ChangePantsEvent;
        private PlayerPantsRepository _repository;

        public void ChangePants(PantsProperties pantsProperties)
        {
            _repository.PantsProperties = pantsProperties;
            ChangePantsEvent?.Invoke(pantsProperties);
        }

        public PantsProperties GetPantsProperties()
        {
            return _repository.PantsProperties;
        }
        
        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _repository = scene.GetRepository<PlayerPantsRepository>();
        }
    }
}