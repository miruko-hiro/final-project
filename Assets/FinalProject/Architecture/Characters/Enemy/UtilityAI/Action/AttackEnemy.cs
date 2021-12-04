using System;
using System.Collections;
using FinalProject.Architecture.Characters.Enemy.UtilityAI.Score;
using FinalProject.Architecture.Characters.Enemy.UtilityAI.Scorers;
using FinalProject.Architecture.Characters.Player.Scripts;
using FinalProject.Architecture.Characters.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Enemy.UtilityAI.Action
{
    public class AttackEnemy: BaseAction
    {
        [SerializeField] private Transform _transformOwn;
        [SerializeField] private AnimationBase _animation;
        
        [Header("Attack parameters")]
        [SerializeField] private float _areaSize = 1f;

        public override bool IsInterrupted { get; protected set; }
        public override bool IsEnabled { get; protected set; }
        
        private ScoreKeeper _scoreKeeper;
        private int _playerLayerIndex;

        private void Awake()
        {
            IsInterrupted = false;
            _scoreKeeper = new ScoreKeeper(GetComponents<Scorer>());
            _playerLayerIndex = LayerMask.GetMask("Player");
        }
        
        public override float GetScores()
        {
            return _scoreKeeper.GetScores();
        }

        public override void Play()
        {
            if(IsEnabled) return;
            IsEnabled = true;
            StartCoroutine(AreaAttackCoroutine());
        }

        public override void Stop()
        {
            IsEnabled = false;
            _animation.Stop();
        }

        private IEnumerator AreaAttackCoroutine()
        {
            _animation.Play();
            var hit = Physics2D.CircleCast(
                _transformOwn.position, 
                _areaSize, 
                Vector2.zero, 
                _playerLayerIndex);

            if (hit && hit.collider)
            {
                var player = hit.collider.GetComponentsInChildren<PlayerView>();
                foreach (var componentsInChild in player) 
                    componentsInChild.TakeHit(1);
            }
            
            yield return new WaitForSeconds(1.3f);
            
            Stop();
        }

        // private void OnDrawGizmos()
        // {
        //     Gizmos.color = Color.green;
        //     Gizmos.DrawSphere(_transformOwn.position, _areaSize);
        // }
    }
}