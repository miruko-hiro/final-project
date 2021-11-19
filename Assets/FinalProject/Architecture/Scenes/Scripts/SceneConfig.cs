using System;
using System.Collections.Generic;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Repositories.Scripts;

namespace FinalProject.Architecture.Scenes.Scripts
{
    public abstract class SceneConfig
    {
        public abstract string SceneName { get; }
        public abstract Dictionary<Type, Interactor> CreateAllInteractors();
        public abstract Dictionary<Type, Repository> CreateAllRepositories();

        public void CreateInteractor<T>(Dictionary<Type, Interactor> interactorsMap) where T : Interactor, new()
        {
            var interactor = new T();
            var type = typeof(T);

            interactorsMap[type] = interactor;
        }

        public void CreateRepository<T>(Dictionary<Type, Repository> repositoriesMap) where T : Repository, new()
        {
            var repository = new T();
            var type = typeof(T);
            
            repositoriesMap[type] = repository;
        }
    }
}