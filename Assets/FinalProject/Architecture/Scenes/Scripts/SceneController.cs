using System;
using System.Collections;
using System.Collections.Generic;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Scenes.Scripts.Config;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Zenject;

namespace FinalProject.Architecture.Scenes.Scripts
{
    public class SceneController : ISceneController
    {
        private const string ConfigFolder = "SceneConfigs";
        public event Action<SceneConfig> OnSceneLoadStartedEvent;
        public event Action<SceneConfig> OnSceneLoadCompletedEvent;
        
        public IScene SceneActual { get; private set; }
        public Dictionary<string, SceneConfig> SceneConfigMap { get; }
        public bool IsLoading { get; private set; }

        public SceneController()
        {
            SceneConfigMap = new Dictionary<string, SceneConfig>();
            InitializeSceneConfigs();
        }
        
        private void InitializeSceneConfigs() {
            var allSceneConfigs = Resources.LoadAll<SceneConfig>(ConfigFolder);
            foreach (var sceneConfig in allSceneConfigs) 
                SceneConfigMap[sceneConfig.SceneName] = sceneConfig;
        }

        public Coroutine LoadScene(Coroutines coroutines, string sceneName, UnityAction<SceneConfig> sceneLoadedCallback = null) {
            return LoadAndInitializeSceneStarter(coroutines, sceneName, sceneLoadedCallback, true);
        }
        
        public Coroutine InitializeCurrentScene(Coroutines coroutines, UnityAction<SceneConfig> sceneLoadedCallback = null) {
            var sceneName = SceneManager.GetActiveScene().name;
            return LoadAndInitializeSceneStarter(coroutines, sceneName, sceneLoadedCallback, false);
        }
        
        protected Coroutine LoadAndInitializeSceneStarter(Coroutines coroutines, string sceneName, UnityAction<SceneConfig> sceneLoadedCallback, bool loadNewScene) {
            SceneConfigMap.TryGetValue(sceneName, out SceneConfig config);
            
            if (config == null)
                throw new NullReferenceException(
                    $"There is no scene ({sceneName}) in the scenes list. The name is wrong or you forget to add it o the list.");

            return coroutines.StartRoutine(LoadSceneCoroutine(coroutines, config, sceneLoadedCallback, loadNewScene));
        }
        
        protected virtual IEnumerator LoadSceneCoroutine(Coroutines coroutines, SceneConfig config, UnityAction<SceneConfig> sceneLoadedCallback, bool loadNewScene = true) {
            IsLoading = true;
            OnSceneLoadStartedEvent?.Invoke(config);
            
            if (loadNewScene)
                yield return coroutines.StartRoutine(LoadSceneAsyncCoroutine(config));
            yield return coroutines.StartRoutine(InitializeSceneCoroutine(coroutines, config, sceneLoadedCallback));

            yield return new WaitForSecondsRealtime(1f);
            IsLoading = false;
            OnSceneLoadCompletedEvent?.Invoke(config);
            sceneLoadedCallback?.Invoke(config);
        }
        
        protected IEnumerator LoadSceneAsyncCoroutine(SceneConfig config) {
            var asyncOperation = SceneManager.LoadSceneAsync(config.SceneName);
            asyncOperation.allowSceneActivation = false;

            var progressDivider = 0.9f;
            var progress = asyncOperation.progress / progressDivider;
            
            while (progress < 1f) {
                yield return null;
                progress = asyncOperation.progress / progressDivider;
            }

            asyncOperation.allowSceneActivation = true;
        }
        protected virtual IEnumerator InitializeSceneCoroutine(Coroutines coroutines, SceneConfig config, UnityAction<SceneConfig> sceneLoadedCallback) {

            SceneActual = new Scene(config);
            yield return null;

            SceneActual.SendMessageOnCreate();
            yield return null;
            
            yield return SceneActual.InitializeStarter(coroutines);

            SceneActual.Start();
        }
    }
}