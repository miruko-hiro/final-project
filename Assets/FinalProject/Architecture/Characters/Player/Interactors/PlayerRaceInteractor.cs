using System;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerRaceInteractor: Interactor
    {
        public event Action<HumanoidRaceProperties> ChangeRaceEvent;
        
        private const string Key = "PLAYER_RACE_PROPERTIES";
        private StorageBase _storage;

        public HumanoidRaceProperties RaceProperties
        {
            get => _storage.Get(Key, new HumanoidRaceProperties(HumanoidRace.Orc, HumanoidGender.Male, 0));
            set
            {
                ChangeRaceEvent?.Invoke(value);
                _storage.Set(Key, value);
            } 
        }
        
        public override void OnInitialize(StorageBase storageBase)
        {
            _storage = storageBase;
        }
    }
}