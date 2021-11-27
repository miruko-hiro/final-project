using System;
using FinalProject.Architecture.Characters.Player.Repositories;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerLevelInteractor: Interactor
    {
        public event Action<int> ChangeLevelEvent;
        
        private PlayerLevelRepository _repository;

        public void ChangeLevel(int level)
        {
            _repository.Level = level;
            ChangeLevelEvent?.Invoke(level);
        }

        public void IncreaseLevel(int increaseBy)
        {
            _repository.Level += increaseBy;
            ChangeLevelEvent?.Invoke(increaseBy);
        }

        public int GetLevel()
        {
            return _repository.Level;
        }
        
        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _repository = scene.GetRepository<PlayerLevelRepository>();
        }
    }
}