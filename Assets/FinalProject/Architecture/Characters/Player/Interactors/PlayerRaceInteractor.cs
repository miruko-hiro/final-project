using System;
using FinalProject.Architecture.Characters.Player.Repositories;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerRaceInteractor: Interactor
    {
        public event Action<HumanoidRaceProperties> ChangeRaceEvent;
        private PlayerRaceRepository _repository;

        public void ChangeRace(HumanoidRaceProperties raceProperties)
        {
            _repository.RaceProperties = raceProperties;
            ChangeRaceEvent?.Invoke(raceProperties);
        }

        public HumanoidRaceProperties GetRaceProperties()
        {
            return _repository.RaceProperties;
        }
        
        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _repository = scene.GetRepository<PlayerRaceRepository>();
        }
    }
}