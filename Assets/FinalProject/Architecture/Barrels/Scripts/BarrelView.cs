using System;
using FinalProject.Architecture.Characters.Enemy.Scripts;
using FinalProject.Architecture.Characters.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Barrels.Scripts
{
    public class BarrelView : MonoBehaviour, IAttackTrigger
    {
        [SerializeField] private CharacterSound _characterSound;
        public event Action<int> OnTakeDamageEvent;
        
        private BarrelPresenter _presenter;
        private Animator _animator;
        private BoxCollider2D _collider;
        private static readonly int Death = Animator.StringToHash("death");

        private void Awake()
        {
            _presenter = new BarrelPresenter(this, new BarrelData(1));
            _animator = GetComponent<Animator>();
            _collider = GetComponent<BoxCollider2D>();
        }

        public void TakeHit(int damage)
        {
            _characterSound.SoundEffect();
            OnTakeDamageEvent?.Invoke(damage);
        }

        public void Die()
        {
            _collider.enabled = false;
            _animator.SetTrigger(Death);
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}
