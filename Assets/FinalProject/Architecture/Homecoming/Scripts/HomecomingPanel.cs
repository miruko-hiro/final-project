using System;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Scenes.MainMenu.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Homecoming.Scripts
{
    public class HomecomingPanel : MonoBehaviour
    {
        private GameManager _gameManager;
        private Coroutines _coroutines;
        private GameStateHelper _gameStateHelper;
        private SoundEffectsButtons _soundEffectsButtons;
        
        [Inject]
        private void Construct(GameManager gameManager, Coroutines coroutines, GameStateHelper gameStateHelper, SoundEffectsButtons soundEffectsButtons)
        {
            _gameManager = gameManager;
            _coroutines = coroutines;
            _gameStateHelper = gameStateHelper;
            _soundEffectsButtons = soundEffectsButtons;
        }

        private void OnEnable()
        {
            _gameStateHelper.Pause();
        }

        public void OnYesButtonClick()
        {
            _soundEffectsButtons.SoundEffectClick();
            _gameManager.SceneController.LoadScene(_coroutines, "FreeZone");
        }
        
        public void OnNoButtonClick()
        {
            _soundEffectsButtons.SoundEffectBack();
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _gameStateHelper.Play();
        }
    }
}
