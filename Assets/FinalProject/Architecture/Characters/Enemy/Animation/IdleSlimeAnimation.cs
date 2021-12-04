using DG.Tweening;
using FinalProject.Architecture.Characters.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Enemy.Animation
{
    public class IdleSlimeAnimation: AnimationBase
    {
        [SerializeField] private Transform _transformOwn;
        private Sequence _sequence;
        
        public override bool IsPlaying { get; protected set; }

        public override void Play(Vector2 direction = default)
        {
            if(IsPlaying) return;
            IsPlaying = true;
            
            if(_sequence != null) _sequence.Restart();
            else _sequence = DOTween.Sequence()
                .Append(_transformOwn.DOScale(new Vector3(9, 9, 1), 0.3f).From(new Vector3(8, 8, 1)))
                .SetLoops(-1, LoopType.Restart)
                .AppendCallback(() => IsPlaying = false)
                .SetAutoKill(false);
        }

        public override void Stop()
        {
            _sequence?.Pause();
            IsPlaying = false;
        }

        private void OnDestroy()
        {
            _sequence?.Kill(true);
        }
    }
}