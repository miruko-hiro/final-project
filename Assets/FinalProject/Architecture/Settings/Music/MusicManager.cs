using FinalProject.Architecture.Game.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Settings.Music
{
    public class MusicManager : MonoBehaviour
    {
        private GameObject _musicObjectPrefab;
        private IMusicSettings _musicSettings;

        public void Initialize(GameManager gameManager)
        {
            _musicObjectPrefab = Resources.Load<GameObject>("MusicObject");
            _musicSettings = gameManager.GameSettings.MusicSettings;
        }

        public MusicObject CreateMusicObject(AudioClip audioClip, Transform parent, bool loop = false)
        {
            var musicObject = CreateObject(parent).GetComponent<MusicObject>();
            musicObject.Initialize(audioClip, _musicSettings.Volume, loop);
            if (!_musicSettings.IsEnabled) musicObject.Pause();
            return musicObject;
        }

        private GameObject CreateObject(Transform parent)
        {
            return Instantiate(_musicObjectPrefab, parent);
        }
    }
}
