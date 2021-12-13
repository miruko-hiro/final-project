using System;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Helpers.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Homecoming.Scripts
{
    public class HomecomingPanel : MonoBehaviour
    {
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

        private void OnEnable()
        {
            _gameStateHelper.Pause();
        }

        public void OnYesButtonClick()
        {
            _gameManager.SceneController.LoadScene(_coroutines, "FreeZone");
        }
        
        public void OnNoButtonClick()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _gameStateHelper.Play();
        }
    }
}
