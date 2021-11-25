using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Repositories
{
    public class PlayerRaceRepository: Repository
    {
        private const string Key = "PLAYER_RACE_PROPERTIES";

        private StorageBase _storage;

        public HumanoidRaceProperties RaceProperties
        {
            get => _storage.Get(Key, new HumanoidRaceProperties(HumanoidRace.Orc, HumanoidGender.Male, 0));
            set => _storage.Set(Key, value);
        }

        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _storage = storageBase;
        }
    }
}