using System;
using UnityEngine;

namespace FinalProject.Architecture.Settings.Music
{
    [Serializable]
    public class MusicSettingsData
    {
        public const float MaxVolume = 1f;
        public const float MinVolume = 0f;

        [SerializeField] private bool _isEnabled;
        [SerializeField] private float _volume;

        public bool IsEnabled
        {
            get => _isEnabled;
            set => _isEnabled = value;
        }

        public float Volume
        {
            get => _volume;
            set => _volume = value;
        }

        public MusicSettingsData()
        {
            _isEnabled = true;
            _volume = MaxVolume;
        }

        public MusicSettingsData(IMusicSettings musicSettings)
        {
            _isEnabled = musicSettings.IsEnabled;
            _volume = musicSettings.Volume;
        }
    }
}