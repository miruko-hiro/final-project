using DG.Tweening;
using FinalProject.Architecture.Characters.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Player.Animation
{
    public class MovementAnimation: AnimationBase
    {
        [SerializeField] private Transform _transformOwn;
        private Sequence _sequence;
        private Vector3 _originalPosition;
        
        public override bool IsPlaying { get; protected set; }

        public override void Play(Vector2 direction = default)
        {
            if(IsPlaying) return;

            IsPlaying = true;
            
            if(_sequence != null) _sequence.Restart();
            else
            {
                _originalPosition = _transformOwn.localPosition;
                _sequence = _transformOwn.DOLocalJump(direction, 0.2f, 1, 0.3f)
                .SetLoops(-1, LoopType.Restart)
                .AppendCallback(() => IsPlaying = false)
                .SetAutoKill(false);
            }
        }

        public override void Stop()
        {
            _sequence?.Pause();
            IsPlaying = false;
            _transformOwn.localPosition = _originalPosition;
        }

        private void OnDestroy()
        {
            _sequence?.Kill(true);
        }
    }
}