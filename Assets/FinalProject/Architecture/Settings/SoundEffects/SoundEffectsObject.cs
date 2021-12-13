using UnityEngine;

namespace FinalProject.Architecture.Settings.SoundEffects
{
    public class SoundEffectsObject : MonoBehaviour
    {
        private AudioSource _source;
        private bool IsKeepAlive { get; set; }

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        public void Initialize(AudioClip clip, Vector3 position, float volume = 1f)
        {
            transform.position = position;

            Initialize(clip, volume);
        }

        public void Initialize(AudioClip clip, float volume = 1f)
        {
            _source.clip = clip;
            _source.volume = volume;

            _source.Play();
        }

        public bool Playing()
        {
            return _source.isPlaying;
        }

        public void Stop()
        {
            _source.Stop();
        }

        private void Update()
        {
            if (!_source.isPlaying)
                if (!IsKeepAlive)
                    Destroy(gameObject);
                else
                    gameObject.SetActive(false);
        }
    }
}