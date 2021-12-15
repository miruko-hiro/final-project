using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Scenes.MainMenu.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Homecoming.Scripts
{
    public class Homecoming : MonoBehaviour
    {
        [SerializeField] private GameObject _homecomingPanel;
        private SoundEffectsButtons _soundEffectsButtons;
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager, SoundEffectsButtons soundEffectsButtons)
        {
            _gameManager = gameManager;
            _soundEffectsButtons = soundEffectsButtons;
        }

        public void OnClick()
        {
            _soundEffectsButtons.SoundEffectClick();
            _gameManager.SaveGame();
            _homecomingPanel.SetActive(true);
        }
    }
}
