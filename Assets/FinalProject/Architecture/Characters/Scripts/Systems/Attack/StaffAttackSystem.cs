using System;
using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Systems.Movement;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Helpers.Scripts;
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
        private PoolMonoZenject<FireAttack> _firePool;
        private const float _cooldown = 1f;
        private float _time = -1f;
        private GameManager _gameManager;
        private PlayerAttackInteractor _interactor;
        private PrefabFactory _prefabFactory;
        
        public MagicType MagicType { get; set; }

        [Inject]
        private void Construct(GameManager gameManager, PrefabFactory prefabFactory)
        {
            _gameManager = gameManager;
            _prefabFactory = prefabFactory;
        }
        
        private void Awake()
        {
            _interactor = _gameManager.GetInteractor<PlayerAttackInteractor>();
            _firePool = new PoolMonoZenject<FireAttack>(_fireAttackPrefab, _prefabFactory, 3, _fireAttackContainer);
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
                fireAttack.Move(direction, _transformPlayer.position, _interactor.Attack);
            }
            else
            {
                _time -= Time.deltaTime;
            }
        }

    }
}