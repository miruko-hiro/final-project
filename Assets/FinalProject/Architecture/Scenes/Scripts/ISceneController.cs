using System;
using System.Collections.Generic;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Scenes.Scripts.Config;
using UnityEngine;
using UnityEngine.Events;

namespace FinalProject.Architecture.Scenes.Scripts
{
    public interface ISceneController
    {
        public event Action<SceneConfig> OnSceneLoadStartedEvent;
        public event Action<SceneConfig> OnSceneLoadCompletedEvent;
        public event Action<float> OnChangeProgressLoadEvent;
        
        public IScene SceneActual { get; }
        public Dictionary<string, SceneConfig> SceneConfigMap { get; }

        Coroutine LoadScene(Coroutines coroutines, string sceneName, UnityAction<SceneConfig> sceneLoadedCallback = null);
        Coroutine InitializeCurrentScene(Coroutines coroutines, UnityAction<SceneConfig> sceneLoadedCallback = null);
    }
}