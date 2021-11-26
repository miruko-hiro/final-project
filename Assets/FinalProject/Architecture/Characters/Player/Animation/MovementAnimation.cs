using DG.Tweening;
using FinalProject.Architecture.Characters.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Player.Animation
{
    public class MovementAnimation: AnimationHumanoid
    {
        [SerializeField] private Transform _transformOwn;
        private Sequence _sequence;
        public override void Play(Vector2 direction = default)
        {
            if(IsPlaying) return;

            IsPlaying = true;
            
            if(_sequence != null) _sequence.Restart();
            else _sequence = _transformOwn.DOLocalJump(direction, 0.2f, 1, 0.3f)
                .AppendCallback(() => IsPlaying = false)
                .SetAutoKill(false);
        }

        public override void Stop()
        {
            _sequence?.Kill(true);
            IsPlaying = false;
        }

        private void OnDestroy()
        {
            _sequence?.Kill(true);
        }
    }
}