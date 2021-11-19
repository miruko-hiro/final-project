using System.Collections;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Repositories.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.Scripts
{
    public class Scene
    {
        private InteractorsBase _interactorsBase;
        private RepositoriesBase _repositoriesBase;
        private SceneConfig _sceneConfig;

        public Scene(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
            
            _interactorsBase = new InteractorsBase(_sceneConfig);
            _repositoriesBase = new RepositoriesBase(_sceneConfig);
        }

        public Coroutine InitializeAsync()
        {
            return Coroutines.StartRoutine(InitializeRoutine());
        }

        private IEnumerator InitializeRoutine()
        {
            _interactorsBase.CreateAllInteractors();
            _repositoriesBase.CreateAllRepositories();
            yield return null;
            
            _interactorsBase.SendOnCreateToAllInteractors();
            _repositoriesBase.SendOnCreateToAllRepositories();
            yield return null;
            
            _interactorsBase.InitializeToAllInteractors();
            _repositoriesBase.InitializeToAllRepositories();
            yield return null;
            
            _interactorsBase.SendOnStartToAllInteractors();
            _repositoriesBase.SendOnStartToAllRepositories();
            yield return null;
        }

        public T GetRepository<T>() where T : Repository
        {
            return _repositoriesBase.GetRepository<T>();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return _interactorsBase.GetInteractor<T>();
        }
    }
}