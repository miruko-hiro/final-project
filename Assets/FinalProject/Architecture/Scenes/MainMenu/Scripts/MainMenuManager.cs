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

        [Inject]
        private void Construct(GameManager gameManager, Coroutines coroutines)
        {
            _gameManager = gameManager;
            _coroutines = coroutines;
        }

        private void Start()
        {
            _transformMenu.DOScale(new Vector3(1f, 1f, 1f), 2f).From(new Vector3(0f, 0f, 0f));
        }

        public void OnNewGame()
        {
            _gameManager.DeleteSave();
            _gameManager.SceneController.LoadScene(_coroutines, "PlayerCreation");
        }
        
        public void OnContinue()
        {
            _gameManager.SceneController.LoadScene(_coroutines, "FreeZone");
        }
    }
}
