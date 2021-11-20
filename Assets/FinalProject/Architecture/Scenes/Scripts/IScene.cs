using System.Collections.Generic;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Configs;
using FinalProject.Architecture.Storage.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.Scripts
{
    public interface IScene
    {
        public SceneConfig SceneConfig { get; }
        
        public ComponentsBase<IRepository> RepositoriesBase { get; }
        public ComponentsBase<IInteractor> InteractorsBase { get; }
        public StorageBase Storage { get; }

        public void SendMessageOnCreate();
        public Coroutine InitializeStarter();
        public void Start();
        public void Save();

        public T GetRepository<T>() where T : IRepository;
        public IEnumerable<T> GetRepositories<T>() where T : IRepository;

        public T GetInteractor<T>() where T : IInteractor;
        public IEnumerable<T> GetInteractors<T>() where T : IInteractor;
    }
}