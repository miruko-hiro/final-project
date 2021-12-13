using System;
using FinalProject.Architecture.Game.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FinalProject.Architecture.Scenes.MainMenu.Scripts
{
    public class SettingsPanel : MonoBehaviour
    {
        public event Action OnMusicClickEvent;
        public event Action OnSoundClickEvent;
        
        [SerializeField] private Image _imageMusicButton;
        [SerializeField] private Image _imageSoundButton;
        private SettingsPanelPresenter _presenter;
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void Awake()
        {
            _presenter = new SettingsPanelPresenter(this, _gameManager.GameSettings.MusicSettings, _gameManager.GameSettings.SoundEffectsSettings);
        }

        public void EnableMusic()
        {
            if(_imageMusicButton == null) return;
            Color32 tempColor = _imageMusicButton.color;
            tempColor.a = 255;
            _imageMusicButton.color = tempColor;
        }

        public void DisableMusic()
        {
            if(_imageMusicButton == null) return;
            Color32 tempColor = _imageMusicButton.color;
            tempColor.a = 100;
            _imageMusicButton.color = tempColor;
        }

        public void EnableSound()
        {
            if(_imageSoundButton == null) return;
            Color32 tempColor = _imageSoundButton.color;
            tempColor.a = 255;
            _imageSoundButton.color = tempColor;
        }

        public void DisableSound()
        {
            if(_imageSoundButton == null) return;
            Color32 tempColor = _imageSoundButton.color;
            tempColor.a = 100;
            _imageSoundButton.color = tempColor;
        }

        public void OnMusicClick()
        {
            OnMusicClickEvent?.Invoke();
        }

        public void OnSoundClick()
        {
            OnSoundClickEvent?.Invoke();
        }
        
        public void OnBackClick()
        {
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}
