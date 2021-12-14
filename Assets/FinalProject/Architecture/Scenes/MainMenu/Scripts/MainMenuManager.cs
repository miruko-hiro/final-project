using System;
using DG.Tweening;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Helpers.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.MainMenu.Scripts
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Transform _transformMenu;
        private GameManager _gameManager;
        private Coroutines _coroutines;
        private SoundEffectsButtons _soundEffectsButtons;

        [Inject]
        private void Construct(GameManager gameManager, Coroutines coroutines, SoundEffectsButtons soundEffectsButtons)
        {
            _gameManager = gameManager;
            _coroutines = coroutines;
            _soundEffectsButtons = soundEffectsButtons;
        }

        private void Start()
        {
            _transformMenu.DOScale(new Vector3(1f, 1f, 1f), 2f).From(new Vector3(0f, 0f, 0f));
        }

        public void OnNewGame()
        {
            _soundEffectsButtons.SoundEffectClick();
            _gameManager.DeleteSave();
            _gameManager.SceneController.LoadScene(_coroutines, "PlayerCreation");
        }
        
        public void OnContinue()
        {
            _soundEffectsButtons.SoundEffectClick();
            _gameManager.SceneController.LoadScene(_coroutines, "FreeZone");
        }
    }
}
