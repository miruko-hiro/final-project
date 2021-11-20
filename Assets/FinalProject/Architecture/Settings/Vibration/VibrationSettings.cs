using System;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture.Settings.Vibration
{
    public class VibrationSettings: IVibrationSettings
    {
        private const string Key = "VIBRATION_SETTINGS";
        
        public event Action OnStateChangedEvent;

        public bool IsEnabled
        {
            get => _vibrationData.IsVibrationEnabled;
            set
            {
                _vibrationData.IsVibrationEnabled = value;
                OnStateChangedEvent?.Invoke();
            }
        }

        private StorageBase _gameSettingsStorage;
        private VibrationSettingsData _vibrationData;
        
        public VibrationSettings(StorageBase gameSettingsStorage) 
        {
            _gameSettingsStorage = gameSettingsStorage;
            var vibrationDataDefault = new VibrationSettingsData();
            var loadedData = gameSettingsStorage.Get(Key, vibrationDataDefault);
            _vibrationData = loadedData;
        }
		

        public void Save() 
        {
            _gameSettingsStorage.Set(Key, _vibrationData);
        }

        public override string ToString() 
        {
            return $"Vibration: is enabled = {IsEnabled}";
        }
    }
}