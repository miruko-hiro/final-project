using UnityEngine;

namespace FinalProject.Architecture.Characters.Enemy.UtilityAI.Scorers
{
    public class ScorerWithoutCondition: Scorer
    {
        [SerializeField] private float _score;

        public override float GetScore()
        {
            return _score;
        }
    }
}