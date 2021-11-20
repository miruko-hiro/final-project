using System;
using FinalProject.Architecture.Settings.Scripts;

namespace FinalProject.Architecture.Settings.Vibration
{
    public interface IVibrationSettings: ISettings
    {
        public event Action OnStateChangedEvent;
		
        public bool IsEnabled { get; set; }
    }
}