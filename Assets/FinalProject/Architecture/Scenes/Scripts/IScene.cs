using System;
using System.Collections.Generic;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Scenes.Scripts.Config;
using FinalProject.Architecture.Storage.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.Scripts
{
    public interface IScene
    {
        public SceneConfig SceneConfig { get; }
        
        public ComponentsBase<IInteractor> InteractorsBase { get; }
        public StorageBase Storage { get; }

        public void SendMessageOnCreate();
        public Coroutine InitializeStarter(Coroutines coroutines);
        public void Start();
        public void Save();
        public void SaveAsync(Action callback = null);

        public T GetInteractor<T>() where T : IInteractor;
        public IEnumerable<T> GetInteractors<T>() where T : IInteractor;
    }
}