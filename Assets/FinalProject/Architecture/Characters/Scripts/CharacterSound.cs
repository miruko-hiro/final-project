using FinalProject.Architecture.Settings.SoundEffects;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Characters.Scripts
{
    public class CharacterSound : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioClip;
        private SoundEffectsCollection _soundEffectsCollection;

        [Inject]
        private void Construct(SoundEffectsCollection soundEffectsCollection)
        {
            _soundEffectsCollection = soundEffectsCollection;
        }

        public void SoundEffect()
        {
            _soundEffectsCollection.AddSoundEffect(_audioClip);
        }
    }
}
