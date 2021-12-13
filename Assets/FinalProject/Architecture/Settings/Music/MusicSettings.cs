using System;
using FinalProject.Architecture.Storage.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Settings.Music
{
    public class MusicSettings: IMusicSettings
    {
        private const string Key = "MUSIC_SETTINGS";
        
        public event Action OnVolumeChangedEvent;
        public event Action OnEnabledEvent;
        public event Action OnDisabledEvent;

        public bool IsEnabled
        {
            get => _musicData.IsEnabled;
            set
            {
                _musicData.IsEnabled = value;
                if(value) OnEnabledEvent?.Invoke();
                else OnDisabledEvent?.Invoke();
            }
        }

        public float Volume
        {
            get => _musicData.Volume;
            set
            {
                _musicData.Volume = Mathf.Clamp(value, MusicSettingsData.MinVolume, MusicSettingsData.MaxVolume);
                OnVolumeChangedEvent?.Invoke();
            }
        }
        
        private MusicSettingsData _musicData;
        private StorageBase _gameSettingsStorage;

        public MusicSettings(StorageBase gameSettingsStorage)
        {
            _gameSettingsStorage = gameSettingsStorage;
            var musicDataByDefault = new MusicSettingsData();
            var loadedData = gameSettingsStorage.Get(Key, musicDataByDefault);
            _musicData = loadedData;
        }

        public void Save()
        {
            _gameSettingsStorage.Set(Key, _musicData);
            _gameSettingsStorage.Save();
        }
        
        public override string ToString()
        {
            return $"Music: is enabled = {IsEnabled}, volume = {Volume}";
        }
    }
}