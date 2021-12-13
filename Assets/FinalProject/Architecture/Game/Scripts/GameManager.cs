using System;
using System.Collections;
using System.Collections.Generic;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Interactors.Scripts;
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

        [Inject]
        public GameManager(Coroutines coroutines)
        {
            Run(coroutines);
        }
        
        private void Run(Coroutines coroutines) {
            state = ArchitectureComponentState.Initializing;

            InitGameSettings();
            
            InitSceneManager();

            SceneController.InitializeCurrentScene(coroutines);

            state = ArchitectureComponentState.Initialized;
            OnGameInitializedEvent?.Invoke();
        }
        
        private void InitGameSettings() {
            GameSettings = new GameSettings();
        }

        private void InitSceneManager() {
            SceneController = new SceneController();
        }
        
        public T GetInteractor<T>() where T : IInteractor {
            return SceneController.SceneActual.GetInteractor<T>();
        }

        public IEnumerable<T> GetInteractors<T>() where T : IInteractor {
            return SceneController.SceneActual.GetInteractors<T>();
        }
        
        public void SaveGame() {
            SceneController.SceneActual.Save();
        }

        public void SaveGameAsync(Action callback) {
            SceneController.SceneActual.SaveAsync(callback);
        }

        public IEnumerator SaveGameStarter(Coroutines coroutines, Action callback = null) {
            yield return SceneController.SceneActual.Storage.SaveStarter(coroutines);
        }

        public void DeleteSave()
        {
            SceneController.SceneActual.DeleteSave();
        }
    }
}