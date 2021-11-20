using FinalProject.Architecture.Characters.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Player.Animation
{
    public class MeleeAttackAnimation : AnimationHumanoid
    {
        [SerializeField] private GameObject _effectPrefab;
        private Animator _animator;
        private static readonly int IsAttack = Animator.StringToHash("isAttack");

        private void Start()
        {
            _animator = Instantiate(_effectPrefab, transform).GetComponent<Animator>();
        }

        public override void Play()
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