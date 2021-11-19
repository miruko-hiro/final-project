using System;
using System.Collections;
using System.Collections.Generic;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Repositories.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FinalProject.Architecture.Scenes.Scripts
{
    public abstract class SceneManagerBase
    {
        public event Action<Scene> OnSceneLoadedEvent;
        public Scene Scene { get; private set; }
        public bool IsLoading { get; private set; }

        protected Dictionary<string, SceneConfig> _sceneConfigMap;

        public SceneManagerBase()
        {
            _sceneConfigMap = new Dictionary<string, SceneConfig>();
            InitSceneMap();
        }

        public abstract void InitSceneMap();

        public Coroutine LoadCurrentSceneAsync()
        {
            if(IsLoading)
                throw new Exception("Scene is loading now");

            var sceneName = SceneManager.GetActiveScene().name;
            var config = _sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(LoadCurrentSceneRoutine(config));
        }

        private IEnumerator LoadCurrentSceneRoutine(SceneConfig sceneConfig)
        {
            IsLoading = true;

            yield return Coroutines.StartRoutine(InitializeSceneAsync(sceneConfig));
            
            IsLoading = false;
            OnSceneLoadedEvent?.Invoke(Scene);
        }

        public Coroutine LoadNewSceneAsync(string sceneName)
        {
            if(IsLoading)
                throw new Exception("Scene is loading now");

            var config = _sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(LoadNewSceneRoutine(config));
        }

        private IEnumerator LoadNewSceneRoutine(SceneConfig sceneConfig)
        {
            IsLoading = true;

            yield return Coroutines.StartRoutine(LoadSceneAsync(sceneConfig));
            yield return Coroutines.StartRoutine(InitializeSceneAsync(sceneConfig));
            
            IsLoading = false;
            OnSceneLoadedEvent?.Invoke(Scene);
        }

        private IEnumerator LoadSceneAsync(SceneConfig sceneConfig)
        {
            var async = SceneManager.LoadSceneAsync(sceneConfig.SceneName);
            async.allowSceneActivation = false;

            while (async.progress < 0.9f)
            {
                yield return null;
            }

            async.allowSceneActivation = true;
        }
        
        private IEnumerator InitializeSceneAsync(SceneConfig sceneConfig)
        {
            Scene = new Scene(sceneConfig);
            yield return Scene.InitializeAsync();
        }

        public T GetRepository<T>() where T : Repository
        {
            return Scene.GetRepository<T>();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return Scene.GetInteractor<T>();
        }
    }
}