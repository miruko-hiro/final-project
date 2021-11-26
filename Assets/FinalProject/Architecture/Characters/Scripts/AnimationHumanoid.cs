using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts
{
    public abstract class AnimationHumanoid : MonoBehaviour
    {
        public bool IsPlaying { get; protected set; }
        public abstract void Play(Vector2 direction = default);
        public abstract void Stop();
    }
}