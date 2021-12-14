using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.MainMenu.Scripts
{
    public class CreatorsPanel : MonoBehaviour
    {
        private string _developerURL = "https://play.google.com/store/apps/developer?id=MRKHR";
        private SoundEffectsButtons _soundEffectsButtons;

        [Inject]
        private void Construct(SoundEffectsButtons soundEffectsButtons)
        {
            _soundEffectsButtons = soundEffectsButtons;
        }

        public void OnGooglePlayClick()
        {
            _soundEffectsButtons.SoundEffectClick();
            Application.OpenURL(_developerURL);
        }
        
        public void OnBackClick()
        {
            _soundEffectsButtons.SoundEffectBack();
            gameObject.SetActive(false);
        }
    }
}