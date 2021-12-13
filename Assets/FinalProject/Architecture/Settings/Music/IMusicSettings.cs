using System;
using FinalProject.Architecture.Settings.Scripts;

namespace FinalProject.Architecture.Settings.Music
{
    public interface IMusicSettings: ISettings
    {
        public event Action OnVolumeChangedEvent;

        public event Action OnEnabledEvent;
        public event Action OnDisabledEvent;
        
        public bool IsEnabled { get; set; }
        public float Volume { get; set; }
    }
}
