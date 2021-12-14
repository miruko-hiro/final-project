using FinalProject.Architecture.Scenes.MainMenu.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Homecoming.Scripts
{
    public class Homecoming : MonoBehaviour
    {
        [SerializeField] private GameObject _homecomingPanel;
        private SoundEffectsButtons _soundEffectsButtons;

        [Inject]
        private void Construct(SoundEffectsButtons soundEffectsButtons)
        {
            _soundEffectsButtons = soundEffectsButtons;
        }

        public void OnClick()
        {
            _soundEffectsButtons.SoundEffectClick();
            _homecomingPanel.SetActive(true);
        }
    }
}
