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
        [SerializeField] private AnimationHumanoid _animation;
        public override bool IsEnabled { get; protected set; }

        private ScoreKeeper _scoreKeeper;

        private void Awake()
        {
            _scoreKeeper = new ScoreKeeper(GetComponents<Scorer>());
        }

        public override float GetScores()
        {
            return _scoreKeeper.GetScores();
        }

        public override void Play()
        {
            if(IsEnabled) return;
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