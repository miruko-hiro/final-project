using System.Collections;
using FinalProject.Architecture.Characters.Enemy.Scripts;
using FinalProject.Architecture.Characters.Player.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Traps.Scripts
{
    public class SpikeTrap: Trap
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
            StartCoroutine(TrapActiveCoroutine(other));
        }

        private IEnumerator TrapActiveCoroutine(Collider2D other)
        {
            _collider.enabled = false;
            _animator.SetBool(IsActive, true);
            
            yield return new WaitForSeconds(0.25f);

            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerView>().TakeHit(_damage);
            } else if (other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyView>().TakeHit(_damage);
            }
            
            yield return new WaitForSeconds(0.25f);
            
            _animator.SetBool(IsActive, false);
            _collider.enabled = true;
        }
    }
}