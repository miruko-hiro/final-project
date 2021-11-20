using System;
using FinalProject.Architecture.Storage.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Settings.SoundEffects
{
    public class SoundEffectsSettings: ISoundEffectsSettings
    {
        private const string Key = "SOUND_EFFECTS_SETTINGS";
        
        public event Action OnVolumeChangedEvent;

        public bool IsEnabled
        {
            get => _soundEffectsData.IsEnabled;
            set
            {
                _soundEffectsData.IsEnabled = value;
                OnVolumeChangedEvent?.Invoke();
            }
        }

        public float Volume
        {
            get => _soundEffectsData.Volume;
            set
            {
                _soundEffectsData.Volume = Mathf.Clamp(value, SoundEffectsSettingsData.MinVolume, SoundEffectsSettingsData.MaxVolume);
                OnVolumeChangedEvent?.Invoke();
            }
        }
        
        private SoundEffectsSettingsData _soundEffectsData;
        private StorageBase _gameSettingsStorage;

        public SoundEffectsSettings(StorageBase gameSettingsStorage)
        {
            _gameSettingsStorage = gameSettingsStorage;
            var soundEffectsDataByDefault = new SoundEffectsSettingsData();
            var loadedData = gameSettingsStorage.Get(Key, soundEffectsDataByDefault);
            _soundEffectsData = loadedData;
        }

        public void Save()
        {
            _gameSettingsStorage.Set(Key, _soundEffectsData);
            _gameSettingsStorage.Save();
        }
        
        public override string ToString()
        {
            return $"SoundEffects: is enabled = {IsEnabled}, volume = {Volume}";
        }
    }
}