using UnityEngine;

namespace Core.Animation
{
    public abstract class AnimationHumanoid : MonoBehaviour
    {
        protected bool IsPlaying;
        public abstract void Play();
        public abstract void Stop();
    }
}