using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Settings.Music;
using FinalProject.Architecture.Settings.SoundEffects;
using FinalProject.Architecture.Settings.Vibration;
using FinalProject.Architecture.Storage.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Settings.Scripts
{
    public class GameSettings: IGameSettings
    {
        private const string SettingsFileName = "GameSettings.data"; 

        public IMusicSettings MusicSettings { get; }
        public ISoundEffectsSettings SoundEffectsSettings { get; }
        public IVibrationSettings VibrationSettings { get; }
        public bool IsLoggingEnabled { get; set; }

        private StorageBase _settingsStorage;
        
        public GameSettings(bool isLoggingEnabled = false) {
            IsLoggingEnabled = isLoggingEnabled;
			
            _settingsStorage = new FileStorage(SettingsFileName);
            _settingsStorage.Load();
			
            MusicSettings = new MusicSettings(_settingsStorage);
            SoundEffectsSettings = new SoundEffectsSettings(_settingsStorage);
            VibrationSettings = new VibrationSettings(_settingsStorage);

            if (isLoggingEnabled) 
                Debug.Log($"GAME SETTINGS LOADED: \n{MusicSettings}\n{SoundEffectsSettings}\n{VibrationSettings}");
        }
        
        public void Save()
        {
            MusicSettings.Save();
            SoundEffectsSettings.Save();
            VibrationSettings.Save();
			
            if (IsLoggingEnabled) 
                Debug.Log($"GAME SETTINGS SAVED: \n{MusicSettings}\n{SoundEffectsSettings}\n{VibrationSettings}");
        }
    }
}