using System;
using System.Collections;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture
{
    public class ArchitectureComponent: IArchitectureComponent
    {
        public event Action OnInitializedEvent;
        
        public ArchitectureComponentState State { get; private set; }
        public bool IsInitialized => State == ArchitectureComponentState.Initialized;
        public bool IsLoggingEnabled { get; set; }

        public ArchitectureComponent()
        {
            State = ArchitectureComponentState.NotInitialized;
        }

        public virtual void OnCreate() { }

        public void InitializeStarter()
        {
            if (IsInitialized)
                throw new Exception($"Component {this.GetType().Name} is already initialized");

            if (State == ArchitectureComponentState.Initializing)
                throw new Exception($"Component {this.GetType().Name} is initializing now");

            InitializeCoroutineInternal();
        }
        
        private void InitializeCoroutineInternal() {
            State = ArchitectureComponentState.Initializing;
            InitializeCoroutine();
            Initialize();

            State = ArchitectureComponentState.Initialized;
            OnInitializedEvent?.Invoke();
        }
        
        /// <summary>
        /// Initialization contains two parts: with routine and without routine. This method (with routine) runs
        /// BEFORE initialization without routine.
        /// </summary>
        protected virtual void InitializeCoroutine() {
            
        }
        
        /// <summary>
        /// Initialization contains two parts: with routine and without routine. This method (without routine) runs
        /// AFTER initialization with routine.
        /// </summary>
        protected virtual void Initialize() { }

        public virtual void OnInitialize(StorageBase storageBase) { }

        public virtual void OnStart() { }

        protected void Log(string text) {
            if (IsLoggingEnabled)
                Debug.Log(text);
        }
    }
}