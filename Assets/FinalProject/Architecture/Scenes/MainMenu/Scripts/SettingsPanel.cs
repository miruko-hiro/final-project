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
        private SoundEffectsButtons _soundEffectsButtons;

        [Inject]
        private void Construct(GameManager gameManager, SoundEffectsButtons soundEffectsButtons)
        {
            _gameManager = gameManager;
            _soundEffectsButtons = soundEffectsButtons;
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
            _soundEffectsButtons.SoundEffectClick();
            OnMusicClickEvent?.Invoke();
        }

        public void OnSoundClick()
        {
            _soundEffectsButtons.SoundEffectClick();
            OnSoundClickEvent?.Invoke();
        }
        
        public void OnBackClick()
        {
            _soundEffectsButtons.SoundEffectBack();
            gameObject.SetActive(false);    
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}
