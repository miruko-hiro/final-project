using FinalProject.Architecture.Game.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Settings.SoundEffects
{
    public class SoundEffectsCollection : MonoBehaviour
    {
        private SoundEffectsManager _soundEffectsManager;
        private ISoundEffectsSettings _soundEffectsSettings;
        private SoundEffectsObject _soundEffectsObject;

        public void Initialize(SoundEffectsManager soundEffectsManager, GameManager gameManager)
        {
            if(_soundEffectsManager != null) return;
            _soundEffectsManager = soundEffectsManager;
            _soundEffectsSettings = gameManager.GameSettings.SoundEffectsSettings;
            _soundEffectsManager.Initialize(gameManager);
        }
        

        public void AddSoundEffect(AudioClip audioClip)
        {
            if(_soundEffectsSettings.IsEnabled)
                _soundEffectsManager.CreateSoundEffectsObject(audioClip, transform);
        }
    }
}