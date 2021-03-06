using System;
using FinalProject.Architecture.Characters.Enemy.Scripts;
using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Systems.Movement;
using FinalProject.Architecture.Game.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Characters.Scripts.Systems.Attack
{
    public class MeleeAttackSystem : MonoBehaviour
    {
        [SerializeField] private InputControl _inputControl;
        [SerializeField] private Transform _attackTransform;
        [SerializeField] private AnimationBase _animationAttack;
        [SerializeField] private Transform _transformPlayer;
        private int _enemyLayerIndex;
        private int _staticsLayerIndex;
        private GameManager _gameManager;
        private PlayerAttackInteractor _interactor;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void Awake()
        {
            _interactor = _gameManager.GetInteractor<PlayerAttackInteractor>();
            _enemyLayerIndex = LayerMask.GetMask("Enemy");
            _staticsLayerIndex = LayerMask.GetMask("Statics");
        }

        private void Update()
        {
            Attack(_inputControl.CurrentInput());
        }

        private void Attack(Vector2 direction)
        {
            if (direction == Vector2.zero)
            {
                _animationAttack.Stop();
                return;
            }

            if (!_animationAttack.IsPlaying)
            {
                float angle = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;
                _attackTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                var denominator = Mathf.Abs(Mathf.Abs(direction.x) - Mathf.Abs(direction.y)) < 0.01f ? 2f : 1.5f;
                
                _attackTransform.localPosition = direction / denominator;
                _animationAttack.Play(direction);

                Hit(direction);
            }
        }

        private void Hit(Vector2 direction)
        {
            var pos = (Vector2) _transformPlayer.position;
            var hits = Physics2D.BoxCastAll(
                pos,
                new Vector2(2.2f, 2.2f),
                0f,
                direction,
                1f,
                _enemyLayerIndex | _staticsLayerIndex);

            if (hits.Length <= 0) return;

            foreach (var hit in hits)
            {
                hit.collider.GetComponent<IAttackTrigger>().TakeHit(_interactor.Attack);
            }
        }

        
    }
}