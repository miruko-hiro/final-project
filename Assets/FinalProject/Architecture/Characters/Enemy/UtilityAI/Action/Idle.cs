using FinalProject.Architecture.Characters.Enemy.UtilityAI.Score;
using FinalProject.Architecture.Characters.Enemy.UtilityAI.Scorers;
using FinalProject.Architecture.Characters.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Enemy.UtilityAI.Action
{
    public class Idle: BaseAction
    {
        [SerializeField] private AnimationBase _animation;
        
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
            IsEnabled = true;
            _animation.Play();
        }

        public override void Stop()
        {
            IsEnabled = false;
            _animation.Stop();
        }
    }
}