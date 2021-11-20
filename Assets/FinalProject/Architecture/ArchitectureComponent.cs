using System;
using System.Collections;
using FinalProject.Architecture.Helpers.Scripts;
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

        public Coroutine InitializeStarter(Coroutines coroutines)
        {
            if (IsInitialized)
                throw new Exception($"Component {this.GetType().Name} is already initialized");

            if (State == ArchitectureComponentState.Initializing)
                throw new Exception($"Component {this.GetType().Name} is initializing now");

            return coroutines.StartRoutine(InitializeCoroutineInternal(coroutines));
        }
        
        private IEnumerator InitializeCoroutineInternal(Coroutines coroutines) {
            State = ArchitectureComponentState.Initializing;
            yield return coroutines.StartRoutine(InitializeCoroutine());
            Initialize();

            State = ArchitectureComponentState.Initialized;
            OnInitializedEvent?.Invoke();
        }
        
        /// <summary>
        /// Initialization contains two parts: with routine and without routine. This method (with routine) runs
        /// BEFORE initialization without routine.
        /// </summary>
        protected virtual IEnumerator InitializeCoroutine() {
            yield break;
        }
        
        /// <summary>
        /// Initialization contains two parts: with routine and without routine. This method (without routine) runs
        /// AFTER initialization with routine.
        /// </summary>
        protected virtual void Initialize() { }

        public virtual void OnInitialize() { }

        public virtual void OnStart() { }

        protected void Log(string text) {
            if (IsLoggingEnabled)
                Debug.Log(text);
        }
    }
}