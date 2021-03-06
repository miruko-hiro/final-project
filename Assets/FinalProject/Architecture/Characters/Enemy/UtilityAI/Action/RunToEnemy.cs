using FinalProject.Architecture.Characters.Enemy.UtilityAI.Score;
using FinalProject.Architecture.Characters.Enemy.UtilityAI.Scorers;
using FinalProject.Architecture.Characters.Scripts;
using Pathfinding;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Enemy.UtilityAI.Action
{
    public class RunToEnemy : BaseAction
    {
        [SerializeField] private AIPath _aiPath;
        [SerializeField] private AnimationBase _animation;
        [SerializeField] private ScorerDistanceToDynamicPosition _scorerDistance;
        
        public override bool IsInterrupted { get; protected set; }
        public override bool IsEnabled { get; protected set; }

        private ScoreKeeper _scoreKeeper;

        private void Awake()
        {
            IsInterrupted = true;
            _scoreKeeper = new ScoreKeeper(GetComponents<Scorer>());
        }

        public override float GetScores()
        {
            return _scoreKeeper.GetScores();
        }

        public override void Play()
        {
            if(IsEnabled) return;
            _scorerDistance.IsAggressive = true;
            IsEnabled = true;
            _aiPath.canMove = true;
            _animation.Play();
        }

        public override void Stop()
        {
            IsEnabled = false;
            _aiPath.canMove = false;
            _animation.Stop();
        }
    }
}