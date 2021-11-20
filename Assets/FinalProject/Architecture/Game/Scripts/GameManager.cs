using System;
using System.Collections;
using System.Collections.Generic;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Settings.Scripts;
using Zenject;

namespace FinalProject.Architecture.Game.Scripts
{
    public class GameManager
    {
        public event Action OnGameInitializedEvent;

        public ArchitectureComponentState state { get; private set; } = ArchitectureComponentState.NotInitialized;
        public ISceneController SceneController { get; private set; }
        public IGameSettings GameSettings { get; private set; }

        private Coroutines _coroutines;
        private InjectionClassFactory _injectionClassFactory;

        [Inject]
        public GameManager(Coroutines coroutines, InjectionClassFactory injectionClassFactory)
        {
            _coroutines = coroutines;
            _injectionClassFactory = injectionClassFactory;
        }
        
        public void Run()
        {
            _coroutines.StartRoutine(RunGameCoroutine());
        }
        
        private IEnumerator RunGameCoroutine() {
            state = ArchitectureComponentState.Initializing;

            InitGameSettings();
            yield return null;
            
            InitSceneManager();
            yield return null;

            yield return SceneController.InitializeCurrentScene();

            state = ArchitectureComponentState.Initialized;
            OnGameInitializedEvent?.Invoke();
        }
        
        private void InitGameSettings() {
            GameSettings = _injectionClassFactory.Create<GameSettings>();
        }

        private void InitSceneManager() {
            SceneController = _injectionClassFactory.Create<SceneController>();
        }
        
        public T GetInteractor<T>() where T : IInteractor {
            return SceneController.SceneActual.GetInteractor<T>();
        }

        public IEnumerable<T> GetInteractors<T>() where T : IInteractor {
            return SceneController.SceneActual.GetInteractors<T>();
        }

        public T GetRepository<T>() where T : IRepository {
            return SceneController.SceneActual.GetRepository<T>();
        }
        
        public IEnumerable<T> GetRepositories<T>() where T : IRepository {
            return SceneController.SceneActual.GetRepositories<T>();
        }
        
        public void SaveGame() {
            SceneController.SceneActual.Storage.Save();
        }

        public void SaveGameAsync(Action callback) {
            SceneController.SceneActual.Storage.SaveAsync(callback);
        }

        public IEnumerator SaveGameStarter(Action callback) {
            yield return SceneController.SceneActual.Storage.SaveStarter();
        }
    }
}