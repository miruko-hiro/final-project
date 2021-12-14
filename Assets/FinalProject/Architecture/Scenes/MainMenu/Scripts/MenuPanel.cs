using FinalProject.Architecture.Helpers.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.MainMenu.Scripts
{
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private GameObject _creatorsPanel;
        private ExitHelper _exitHelper;
        private SoundEffectsButtons _soundEffectsButtons;

        [Inject]
        private void Construct(ExitHelper exitHelper, SoundEffectsButtons soundEffectsButtons)
        {
            _exitHelper = exitHelper;
            _soundEffectsButtons = soundEffectsButtons;
        }

        public void OnSettingsClick()
        {
            _soundEffectsButtons.SoundEffectClick();
            _settingsPanel.SetActive(true);
        }

        public void OnCreatorsClick()
        {
            _soundEffectsButtons.SoundEffectClick();
            _creatorsPanel.SetActive(true);
        }

        public void OnExitClick()
        {
            _soundEffectsButtons.SoundEffectBack();
            _exitHelper.Exit();
        }
    }
}
