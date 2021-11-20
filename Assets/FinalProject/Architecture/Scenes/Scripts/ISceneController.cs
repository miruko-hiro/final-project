using System;
using System.Collections.Generic;
using FinalProject.Architecture.Scenes.Configs;
using UnityEngine;
using UnityEngine.Events;

namespace FinalProject.Architecture.Scenes.Scripts
{
    public interface ISceneController
    {
        public event Action<SceneConfig> OnSceneLoadStartedEvent;
        public event Action<SceneConfig> OnSceneLoadCompletedEvent;
        
        public IScene SceneActual { get; }
        public Dictionary<string, SceneConfig> SceneConfigMap { get; }

        Coroutine LoadScene(string sceneName, UnityAction<SceneConfig> sceneLoadedCallback = null);
        Coroutine InitializeCurrentScene(UnityAction<SceneConfig> sceneLoadedCallback = null);
    }
}