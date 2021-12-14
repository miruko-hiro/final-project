using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Settings.SoundEffects;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Teleport
{
    public class TeleportScene : MonoBehaviour
    {
        [SerializeField] private string _sceneName;
        [SerializeField] private AudioClip _audioClip;
        private GameManager _gameManager;
        private Coroutines _coroutines;
        private SoundEffectsCollection _soundEffectsCollection;

        [Inject]
        private void Construct(GameManager gameManager, Coroutines coroutines, SoundEffectsCollection soundEffectsCollection)
        {
            _gameManager = gameManager;
            _coroutines = coroutines;
            _soundEffectsCollection = soundEffectsCollection;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _soundEffectsCollection.AddSoundEffect(_audioClip);
                _gameManager.SceneController.LoadScene(_coroutines, _sceneName);
            }
        }
    }
}