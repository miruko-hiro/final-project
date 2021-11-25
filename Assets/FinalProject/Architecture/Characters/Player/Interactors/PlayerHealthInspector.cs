using System;
using FinalProject.Architecture.Characters.Player.Repositories;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public class PlayerHealthInspector: Interactor
    {
        public event Action<int> ChangeHealthEvent;
        public event Action<int> IncreaseHealthEvent;
        public event Action<int> ReduceHealthEvent;
        
        private PlayerHealthRepository _repository;

        public void ChangeHealth(int health)
        {
            _repository.Health = health;
            ChangeHealthEvent?.Invoke(health);
        }

        public void IncreaseHealth(int increaseBy)
        {
            _repository.Health += increaseBy;
            IncreaseHealthEvent?.Invoke(increaseBy);
        }

        public void ReduceHealth(int reduceBy)
        {
            _repository.Health -= reduceBy;
            ReduceHealthEvent?.Invoke(reduceBy);
        }

        public int GetHealth()
        {
            return _repository.Health;
        }
        
        public override void OnInitialize(StorageBase storageBase, IScene scene)
        {
            _repository = scene.GetRepository<PlayerHealthRepository>();
        }
    }
}