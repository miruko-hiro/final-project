using UnityEngine;

namespace FinalProject.Architecture.Settings.Music
{
    public class MusicObject : MonoBehaviour
    { 
        private AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        public void Initialize(AudioClip clip, Vector3 position, float volume = 1f, bool loop = false)
        {
            transform.position = position;

            Initialize(clip, volume, loop);
        }

        public void Initialize(AudioClip clip, float volume = 1f, bool loop = false)
        {
            _source.clip = clip;
            _source.volume = volume;
            _source.loop = loop;

            _source.Play();
        }

        public void UnPause()
        {
            _source.UnPause();
        }

        public bool Playing()
        {
            return _source.isPlaying;
        }

        public void Pause()
        {
            _source.Pause();
        }

        public void Stop()
        {
            _source.Stop();
        }
    }
}
