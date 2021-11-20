using System;
using UnityEngine;

namespace FinalProject.Architecture.Settings.Vibration
{
    [Serializable]
    public class VibrationSettingsData
    {
        [SerializeField] private bool _isVibrationEnabled;

        public bool IsVibrationEnabled
        {
            get => _isVibrationEnabled;
            set => _isVibrationEnabled = value;
        }

        public VibrationSettingsData()
        {
            _isVibrationEnabled = true;
        }
    }
}