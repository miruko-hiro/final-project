using System;
using FinalProject.Architecture.Game.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FinalProject.Architecture.Scenes.LoadingScreen.Scripts
{
    public class LoadingBarManager : MonoBehaviour
    {
        [SerializeField] private RectTransform _dino;
        [SerializeField] private Image _loadingBar;
        [SerializeField] private RectTransform _leftBackground;
        [SerializeField] private RectTransform _rightBackground;
        private float _x;
        private Vector3 _pos;
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            gameManager.SceneController.OnChangeProgressLoadEvent += SetFill;
            _gameManager = gameManager;
        }

        private void Awake()
        {
            var leftPosition =  _leftBackground.position;
            var rightPosition =  _rightBackground.position;
            
            _x = (rightPosition - leftPosition).x;
            _dino.position = leftPosition;
            _pos = _dino.position;
        }

        public void SetFill(float amount)
        {
            _loadingBar.fillAmount = amount;
            _dino.position = new Vector3(_pos.x + (_x * amount), _pos.y, _pos.z);
        }

        private void OnDestroy()
        {
            _gameManager.SceneController.OnChangeProgressLoadEvent -= SetFill;
        }
    }
}
