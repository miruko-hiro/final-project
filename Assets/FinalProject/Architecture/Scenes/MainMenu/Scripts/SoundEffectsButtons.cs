using FinalProject.Architecture.Settings.SoundEffects;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.MainMenu.Scripts
{
    public class SoundEffectsButtons : MonoBehaviour
    {
        [SerializeField] private AudioClip _soundClick;
        [SerializeField] private AudioClip _soundBack;
        private SoundEffectsCollection _soundEffectsCollection;

        [Inject]
        private void Construct(SoundEffectsCollection soundEffectsCollection)
        {
            _soundEffectsCollection = soundEffectsCollection;
        }

        public void SoundEffectClick()
        {
            _soundEffectsCollection.AddSoundEffect(_soundClick);
        }

        public void SoundEffectBack()
        {
            _soundEffectsCollection.AddSoundEffect(_soundBack);
        }
    }
}
