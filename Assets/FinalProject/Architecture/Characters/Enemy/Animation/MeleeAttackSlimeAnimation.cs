using FinalProject.Architecture.Characters.Enemy.Scripts;
using FinalProject.Architecture.Characters.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace FinalProject.Architecture.Characters.Enemy.Animation
{
    public class MeleeAttackSlimeAnimation: AnimationBase
    {
        [SerializeField] private GameObject _effectPrefab;
        [SerializeField] private CharacterSound characterSound;
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
            
            characterSound.SoundEffect();
            
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