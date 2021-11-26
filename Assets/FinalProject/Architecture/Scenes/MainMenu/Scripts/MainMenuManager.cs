using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Helpers.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.MainMenu.Scripts
{
    public class MainMenuManager : MonoBehaviour
    {
        private ExitHelper _exitHelper;
        private GameManager _gameManager;
        private Coroutines _coroutines;

        [Inject]
        private void Construct(ExitHelper exitHelper, GameManager gameManager, Coroutines coroutines)
        {
            _exitHelper = exitHelper;
            _gameManager = gameManager;
            _coroutines = coroutines;
        }
        
        public void OnNewGame()
        {
            _gameManager.SceneController.LoadScene(_coroutines, "PlayerCreation");
        }
        
        public void OnContinue()
        {
            _gameManager.SceneController.LoadScene(_coroutines, "Battle");
        }

        public void OnExit()
        {
            _exitHelper.Exit();
        }
    }
}
