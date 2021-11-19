using System;
using System.Collections;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Scripts;

namespace FinalProject.Architecture.Game.Scripts
{
    public static class GameManager
    {
        public static event Action OnGameInitializeEvent;
        public static SceneManagerBase SceneManagerBase { get; private set; }
        
        public static void Run()
        {
            SceneManagerBase = new SceneManagerExample();
            Coroutines.StartRoutine(InitializeGameRoutine());
        }

        private static IEnumerator InitializeGameRoutine()
        {
            SceneManagerBase.InitSceneMap();
            yield return SceneManagerBase.LoadCurrentSceneAsync();
            OnGameInitializeEvent?.Invoke();
        }

        public static T GetRepository<T>() where T : Repository
        {
            return SceneManagerBase.GetRepository<T>();
        }

        public static T GetInteractor<T>() where T : Interactor
        {
            return SceneManagerBase.GetInteractor<T>();
        }
    }
}