using DG.Tweening;
using FinalProject.Architecture.Characters.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Player.Animation
{
    public class MovementAnimation: AnimationHumanoid
    {
        [SerializeField] private Transform _transformOwn;
        private Sequence _sequence;
        public override void Play()
        {
            if(IsPlaying) return;

            IsPlaying = true;
            
            if(_sequence != null) _sequence.Restart();
            else _sequence = DOTween.Sequence()
                .Append(_transformOwn.DOLocalRotate(new Vector3(0f, 0f, 4f), 0.05f))
                .Append(_transformOwn.DOLocalRotate(new Vector3(0f, 0f, -4f), 0.05f))
                .Append(_transformOwn.DOLocalRotate(Vector3.zero, 0.02f))
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