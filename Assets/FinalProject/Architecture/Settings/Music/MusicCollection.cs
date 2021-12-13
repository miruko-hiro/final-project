using FinalProject.Architecture.Game.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Settings.Music
{
    public class MusicCollection : MonoBehaviour
    {
        private MusicManager _musicManager;
        private IMusicSettings _musicSettings;
        private MusicObject _musicObject;

        public void Initialize(MusicManager musicManager, GameManager gameManager)
        {
            if(_musicManager != null) return;
            _musicManager = musicManager;
            _musicSettings = gameManager.GameSettings.MusicSettings;
            _musicSettings.OnEnabledEvent += EnabledMusic;
            _musicSettings.OnDisabledEvent += DisabledMusic;
            musicManager.Initialize(gameManager);
        }

        public void AddMusic(AudioClip audioClip)
        {
            if(_musicObject != null) Destroy(_musicObject.gameObject);
            _musicObject = _musicManager.CreateMusicObject(audioClip, transform, true);
        }

        private void EnabledMusic()
        {
            if(_musicObject != null)
                _musicObject.UnPause();
        }

        private void DisabledMusic()
        {
            if(_musicObject != null)
                _musicObject.Pause();
        }

        private void OnDestroy()
        {
            _musicSettings.OnEnabledEvent -= EnabledMusic;
            _musicSettings.OnDisabledEvent -= DisabledMusic;
        }
    }
}