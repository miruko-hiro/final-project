using UnityEngine;

namespace FinalProject.Architecture.Characters.Enemy.UtilityAI.Action
{
    public abstract class BaseAction: MonoBehaviour
    {
        public abstract bool IsEnabled { get; protected set; }
        public abstract float GetScores();
        public abstract void Play();
        public abstract void Stop();
    }
}