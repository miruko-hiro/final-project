using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Helpers.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.MainMenu.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenuPanel;
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

        public void OnClick()
        {
            _soundEffectsButtons.SoundEffectClick();
            _gameStateHelper.Pause();
            _mainMenuPanel.SetActive(true);
        }
        
        public void OnNewGame()
        {
            _soundEffectsButtons.SoundEffectClick();
            _gameManager.DeleteSave();
            _gameManager.SceneController.LoadScene(_coroutines, "PlayerCreation");
        }
        
        public void OnContinue()
        {
            _soundEffectsButtons.SoundEffectBack();
            _mainMenuPanel.SetActive(false);
            _gameStateHelper.Play();
        }
    }
}
