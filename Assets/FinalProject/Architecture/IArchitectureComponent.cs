using System;
using UnityEngine;

namespace FinalProject.Architecture
{
    public interface IArchitectureComponent: IArchitectureCaptureEvents
    {
        public event Action OnInitializedEvent;
        
        public ArchitectureComponentState State { get; }
        public bool IsInitialized { get; }
        public bool IsLoggingEnabled { get; set; }

        public Coroutine InitializeStarter();
    }
}