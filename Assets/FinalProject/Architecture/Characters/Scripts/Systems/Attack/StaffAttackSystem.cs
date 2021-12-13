using System;
using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Systems.Movement;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Utils;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Characters.Scripts.Systems.Attack
{
    public class StaffAttackSystem : MonoBehaviour
    {
        [SerializeField] private InputControl _inputControl;
        [SerializeField] private Transform _transformPlayer;
        [SerializeField] private FireAttack _fireAttackPrefab;
        [SerializeField] private Transform _fireAttackContainer;
        private PoolMono<FireAttack> _firePool;
        private const float _cooldown = 1f;
        private float _time = -1f;
        private GameManager _gameManager;
        private PlayerWeaponInteractor _interactor;
        private int _damage;
        
        public MagicType MagicType { get; set; }

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        private void Awake()
        {
            _interactor = _gameManager.GetInteractor<PlayerWeaponInteractor>();
            _firePool = new PoolMono<FireAttack>(_fireAttackPrefab, 3, _fireAttackContainer);
        }

        private void OnEnable()
        {
            _damage = _interactor.WeaponProperties.AttackScore;
        }

        private void Update()
        {
            Attack(_inputControl.CurrentInput());
        }
        
        private void Attack(Vector2 direction)
        {
            if (direction == Vector2.zero)
            {
                return;
            }

            if (_time < 0f)
            {
                _time = _cooldown;
                var fireAttack = _firePool.GetFreeElement();
                fireAttack.Move(direction, _transformPlayer.position, _damage);
            }
            else
            {
                _time -= Time.deltaTime;
            }
        }

    }
}