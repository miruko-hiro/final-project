using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts
{
    public abstract class AnimationHumanoid : MonoBehaviour
    {
        protected bool IsPlaying;
        public abstract void Play();
        public abstract void Stop();
    }
}