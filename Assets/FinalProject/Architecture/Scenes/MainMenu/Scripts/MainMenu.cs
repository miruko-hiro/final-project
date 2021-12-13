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

        [Inject]
        private void Construct(GameManager gameManager, Coroutines coroutines, GameStateHelper gameStateHelper)
        {
            _gameManager = gameManager;
            _coroutines = coroutines;
            _gameStateHelper = gameStateHelper;
        }

        public void OnClick()
        {
            _gameStateHelper.Pause();
            _mainMenuPanel.SetActive(true);
        }
        
        public void OnNewGame()
        {
            _gameManager.DeleteSave();
            _gameManager.SceneController.LoadScene(_coroutines, "PlayerCreation");
        }
        
        public void OnContinue()
        {
            _mainMenuPanel.SetActive(false);
            _gameStateHelper.Play();
        }
    }
}
