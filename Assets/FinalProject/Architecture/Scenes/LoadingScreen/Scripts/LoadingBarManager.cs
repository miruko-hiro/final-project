using FinalProject.Architecture.Game.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FinalProject.Architecture.Scenes.LoadingScreen.Scripts
{
    public class LoadingBarManager : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private Image _loadingBar;
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            gameManager.SceneController.OnChangeProgressLoadEvent += SetFill;
            _gameManager = gameManager;
        }

        private void Awake()
        {
            _panel.SetActive(false);
        }

        private void SetFill(float amount)
        {
            if(!_panel.activeInHierarchy)
                _panel.SetActive(true);
            _loadingBar.fillAmount = amount;
        }

        private void OnDestroy()
        {
            _gameManager.SceneController.OnChangeProgressLoadEvent -= SetFill;
        }
    }
}
