using System;
using UnityEngine;

namespace FinalProject.Architecture.Settings.SoundEffects
{
    [Serializable]
    public class SoundEffectsSettingsData
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

        public SoundEffectsSettingsData()
        {
            _isEnabled = true;
            _volume = MaxVolume;
        }

        public SoundEffectsSettingsData(ISoundEffectsSettings soundEffectsSettings)
        {
            _isEnabled = soundEffectsSettings.IsEnabled;
            _volume = soundEffectsSettings.Volume;
        }
    }
}