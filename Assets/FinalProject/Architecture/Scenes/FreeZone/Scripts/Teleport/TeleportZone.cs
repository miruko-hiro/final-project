using System;
using FinalProject.Architecture.Settings.SoundEffects;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Teleport
{
    public class TeleportZone : MonoBehaviour
    {
        public event Action OnEnterZone;
            
        [SerializeField] private Vector3 _posTeleport;
        [SerializeField] private Vector3 _posCamera;
        [SerializeField] private Transform _mainCamera;
        [SerializeField] private AudioClip _audioClip;
        private SoundEffectsCollection _soundEffectsCollection;
        
        [Inject]
        private void Construct(SoundEffectsCollection soundEffectsCollection)
        {
            _soundEffectsCollection = soundEffectsCollection;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                OnEnterZone?.Invoke();
                _soundEffectsCollection.AddSoundEffect(_audioClip);
                other.transform.position = _posTeleport;
                _mainCamera.transform.position = _posCamera;
            }
        }
    }
}
