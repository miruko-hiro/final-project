using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Helpers.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Teleport
{
    public class TeleportScene : MonoBehaviour
    {
        [SerializeField] private string _sceneName;
        private GameManager _gameManager;
        private Coroutines _coroutines;

        [Inject]
        private void Construct(GameManager gameManager, Coroutines coroutines)
        {
            _gameManager = gameManager;
            _coroutines = coroutines;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _gameManager.SceneController.LoadScene(_coroutines, _sceneName);
            }
        }
    }
}