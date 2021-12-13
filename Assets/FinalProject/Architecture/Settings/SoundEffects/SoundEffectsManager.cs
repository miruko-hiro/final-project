using FinalProject.Architecture.Game.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Settings.SoundEffects
{
    public class SoundEffectsManager : MonoBehaviour
    {
        private GameObject _soundEffectsObjectPrefab;
        private ISoundEffectsSettings _soundEffectsSettings;

        public void Initialize(GameManager gameManager)
        {
            _soundEffectsObjectPrefab = Resources.Load<GameObject>("SoundEffectsObject");
            _soundEffectsSettings = gameManager.GameSettings.SoundEffectsSettings;
        }

        public SoundEffectsObject CreateSoundEffectsObject(AudioClip audioClip, Transform parent)
        {
            if (!_soundEffectsSettings.IsEnabled) return null;
            var soundEffectsObject = CreateObject(parent).GetComponent<SoundEffectsObject>();
            soundEffectsObject.Initialize(audioClip, _soundEffectsSettings.Volume);
            return soundEffectsObject;
        }

        private GameObject CreateObject(Transform parent)
        {
            return Instantiate(_soundEffectsObjectPrefab, parent);
        }
    }
}