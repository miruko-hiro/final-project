using System;
using System.Collections.Generic;
using FinalProject.Architecture.Scenes.Scripts;

namespace FinalProject.Architecture.Repositories.Scripts
{
    public class RepositoriesBase
    {
        private Dictionary<Type, Repository> _repositoriesMap;
        private SceneConfig _sceneConfig;

        public RepositoriesBase(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }

        public void CreateAllRepositories()
        {
            _repositoriesMap = _sceneConfig.CreateAllRepositories();
        }

        public void SendOnCreateToAllRepositories()
        {
            var allRepositories = _repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.OnCreate();
            }
        }

        public void InitializeToAllRepositories()
        {
            var allRepositories = _repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.Initialize();
            }
        }

        public void SendOnStartToAllRepositories()
        {
            var allRepositories = _repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.OnStart();
            }
        }

        public T GetRepository<T>() where T : Repository
        {
            var type = typeof(T);
            return (T) _repositoriesMap[type];
        }
    }
}