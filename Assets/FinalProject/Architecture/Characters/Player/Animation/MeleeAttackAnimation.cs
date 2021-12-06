using DG.Tweening;
using FinalProject.Architecture.Characters.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Player.Animation
{
    public class MeleeAttackAnimation : AnimationBase
    {
        [SerializeField] private Transform _transformOwn;
        [SerializeField] private GameObject _effectPrefab;
        private Animator _animator;
        private static readonly int IsAttack = Animator.StringToHash("isAttack");

        public override bool IsPlaying { get; protected set; }

        private void Awake()
        {
            _animator = Instantiate(_effectPrefab, transform).GetComponent<Animator>();
        }

        public override void Play(Vector2 direction = default)
        {
            if(IsPlaying) return;

            IsPlaying = true;
            
            _animator.SetBool(IsAttack, true);
            
            DOTween.Sequence()
                .Append(_transformOwn.DOLocalMove(direction / 2f, 0.3f))
                .Append(_transformOwn.DOLocalMove(Vector3.zero, 0.3f))
                .AppendCallback(Stop);
        }

        public override void Stop()
        {
            if(!IsPlaying) return;

            IsPlaying = false;
            
            _animator.SetBool(IsAttack, false);
        }
    }
}