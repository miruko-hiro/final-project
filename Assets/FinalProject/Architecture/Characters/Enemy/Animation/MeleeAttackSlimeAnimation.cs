using FinalProject.Architecture.Characters.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Enemy.Animation
{
    public class MeleeAttackSlimeAnimation: AnimationBase
    {
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
            
            _animator.SetBool(IsAttack, IsPlaying);
        }

        public override void Stop()
        {
            if(!IsPlaying) return;
            IsPlaying = false;
            
            _animator.SetBool(IsAttack, IsPlaying);
        }
    }
}