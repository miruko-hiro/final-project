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

        private Coroutines _coroutines;

        [Inject]
        public ArchitectureComponent(Coroutines coroutines)
        {
            _coroutines = coroutines;
            State = ArchitectureComponentState.NotInitialized;
        }

        public virtual void OnCreate() { }

        public Coroutine InitializeStarter()
        {
            if (IsInitialized)
                throw new Exception($"Component {this.GetType().Name} is already initialized");

            if (State == ArchitectureComponentState.Initializing)
                throw new Exception($"Component {this.GetType().Name} is initializing now");

            return _coroutines.StartRoutine(InitializeCoroutineInternal());
        }
        
        private IEnumerator InitializeCoroutineInternal() {
            State = ArchitectureComponentState.Initializing;
            yield return _coroutines.StartRoutine(InitializeCoroutine());
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