using FinalProject.Architecture.Characters.Enemy.Scripts;
using FinalProject.Architecture.Characters.Player.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Traps.Scripts
{
    public class BearTrap : Trap
    {
        private BoxCollider2D _collider;
        private Animator _animator;
        private static readonly int IsActive = Animator.StringToHash("isActive");

        public override int Damage { get => _damage; set => _damage = value; }

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _collider.enabled = false;
            _animator.SetBool(IsActive, true);
            _sound.SoundEffect();
            if (other.CompareTag("Player"))
            {
                other.GetComponentInChildren<PlayerView>().TakeHit(_damage);
            } else if (other.CompareTag("Enemy"))
            {
                other.GetComponentInChildren<EnemyView>().TakeHit(_damage);
            }
        }
    }
}
