using System;
using System.Collections;
using System.Collections.Generic;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Settings.Scripts;

namespace FinalProject.Architecture.Game.Scripts
{
    public static class GameManager
    {
        public static event Action OnGameInitializedEvent;

        public static ArchitectureComponentState state { get; private set; } = ArchitectureComponentState.NotInitialized;
        public static ISceneController SceneController { get; private set; }
        public static IGameSettings GameSettings { get; private set; }
        
        public static void Run()
        {
            Coroutines.StartRoutine(RunGameCoroutine());
        }
        
        private static IEnumerator RunGameCoroutine() {
            state = ArchitectureComponentState.Initializing;

            InitGameSettings();
            yield return null;
            
            InitSceneManager();
            yield return null;

            yield return SceneController.InitializeCurrentScene();

            state = ArchitectureComponentState.Initialized;
            OnGameInitializedEvent?.Invoke();
        }
        
        private static void InitGameSettings() {
            GameSettings = new GameSettings();
        }

        private static void InitSceneManager() {
            SceneController = new SceneController();
        }
        
        public static T GetInteractor<T>() where T : IInteractor {
            return SceneController.SceneActual.GetInteractor<T>();
        }

        public static IEnumerable<T> GetInteractors<T>() where T : IInteractor {
            return SceneController.SceneActual.GetInteractors<T>();
        }

        public static T GetRepository<T>() where T : IRepository {
            return SceneController.SceneActual.GetRepository<T>();
        }
        
        public static IEnumerable<T> GetRepositories<T>() where T : IRepository {
            return SceneController.SceneActual.GetRepositories<T>();
        }
        
        public static void SaveGame() {
            SceneController.SceneActual.Storage.Save();
        }

        public static void SaveGameAsync(Action callback) {
            SceneController.SceneActual.Storage.SaveAsync(callback);
        }

        public static IEnumerator SaveGameStarter(Action callback) {
            yield return SceneController.SceneActual.Storage.SaveStarter();
        }
    }
}