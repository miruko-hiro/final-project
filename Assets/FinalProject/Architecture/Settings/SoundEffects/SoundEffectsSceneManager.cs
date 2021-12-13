using FinalProject.Architecture.Game.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Settings.SoundEffects
{
    public class SoundEffectsSceneManager : MonoBehaviour
    {
        private GameManager _gameManager;
        private SoundEffectsCollection _soundEffectsCollection;
        private SoundEffectsManager _soundEffectsManager;

        [Inject]
        private void Construct(GameManager gameManager, SoundEffectsCollection soundEffectsCollection, SoundEffectsManager soundEffectsManager)
        {
            _gameManager = gameManager;
            _soundEffectsCollection = soundEffectsCollection;
            _soundEffectsManager = soundEffectsManager;
        }

        private void Awake()
        {
            _soundEffectsCollection.Initialize(_soundEffectsManager, _gameManager);
        }
    }
}