using FinalProject.Architecture.Settings.Music;
using FinalProject.Architecture.Settings.SoundEffects;

namespace FinalProject.Architecture.Scenes.MainMenu.Scripts
{
    public class SettingsPanelPresenter
    {
        private readonly SettingsPanel _view;
        private readonly IMusicSettings _musicSettings; 
        private readonly ISoundEffectsSettings _soundEffectsSettings;

        public SettingsPanelPresenter(SettingsPanel view, IMusicSettings musicSettings, ISoundEffectsSettings soundEffectsSettings)
        {
            _view = view;
            _musicSettings = musicSettings;
            _soundEffectsSettings = soundEffectsSettings;
            
            OnOpen();
        }
        
        private void OnLoad()
        {
            if(_musicSettings.IsEnabled)
                _view.EnableMusic();
            else
                _view.DisableMusic();
            
            if(_soundEffectsSettings.IsEnabled)
                _view.EnableSound();
            else
                _view.DisableSound();
        }

        private void OnOpen()
        {
            OnLoad();
            
            _musicSettings.OnEnabledEvent += EnableMusic;
            _musicSettings.OnDisabledEvent += DisableMusic;
            _soundEffectsSettings.OnEnabledEvent += EnableSound;
            _soundEffectsSettings.OnDisabledEvent += DisableSound;

            _view.OnMusicClickEvent += MusicClick;
            _view.OnSoundClickEvent += SoundClick;
        }

        private void OnClose()
        {
            _musicSettings.OnEnabledEvent -= EnableMusic;
            _musicSettings.OnDisabledEvent -= DisableMusic;
            _soundEffectsSettings.OnEnabledEvent -= EnableSound;
            _soundEffectsSettings.OnDisabledEvent -= DisableSound;

            _view.OnMusicClickEvent -= MusicClick;
            _view.OnSoundClickEvent -= SoundClick;
        }

        private void EnableMusic()
        {
            _view.EnableMusic();
        }

        private void DisableMusic()
        {
            _view.DisableMusic();
        }

        private void EnableSound()
        {
            _view.EnableSound();
        }

        private void DisableSound()
        {
            _view.DisableSound();
        }

        private void MusicClick()
        {
            _musicSettings.IsEnabled = !_musicSettings.IsEnabled;
            _musicSettings.Save();
        }

        private void SoundClick()
        {
            _soundEffectsSettings.IsEnabled = !_soundEffectsSettings.IsEnabled;
            _soundEffectsSettings.Save();
        }

        ~SettingsPanelPresenter()
        {
            OnClose();
        }
    }
}