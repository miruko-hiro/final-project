using UnityEngine;

namespace FinalProject.Architecture.Characters.Enemy.UtilityAI.Scorers
{
    public abstract class Scorer: MonoBehaviour
    {
        public abstract float GetScore();
    }
}